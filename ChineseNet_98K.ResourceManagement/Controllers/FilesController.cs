using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChineseNet_98K.ResourceManagement.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Internal;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;

namespace ChineseNet_98K.ResourceManagement.Controllers
{
    //启用跨域
    [EnableCors("CorsSample")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public async Task<string> Post([FromForm] IFormCollection formCollection)
        {
            string result = "";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            FormFileCollection filelist = (FormFileCollection)formCollection.Files;

            foreach (IFormFile file in filelist)
            {
                String Tpath = "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
                string name = file.FileName;
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string FilePath = webRootPath + Tpath;

                string type = System.IO.Path.GetExtension(name);
                DirectoryInfo di = new DirectoryInfo(FilePath);


                if (!di.Exists) { di.Create(); }

                using (FileStream fs = System.IO.File.Create(FilePath + FileName + type))
                {
                    // 复制文件
                    file.CopyTo(fs);
                    // 清空缓冲区数据
                    fs.Flush();
                }
                result = "1";
            }
            return result;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        //[EnableCors(origins: "http://a.sample.com", headers: "*", methods: "get,post", SupportsCredentials = true)]
        [HttpPost]
        public string UploadFiles(string z)
        {
            long size = 0;
            var path = "";
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                string fileExt = Path.GetExtension(file.FileName); //文件扩展名
                long fileSize = file.Length; //获得文件大小，以字节为单位
                string newFileName = System.Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                path = "/Images/" + newFileName;
                path = _hostingEnvironment.WebRootPath + $@"\{path}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(path))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                path = "/Images/" + newFileName;
            }
            return path;
        }


    }
}