using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using Entity;
    using IBLL;
    using Common;
    using Newtonsoft.Json;
    using System.Web;
    using ChineseNet_98K.Backstage.wwwroot;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    /// <summary>
    /// ** 描述：小说管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class NovelsController : Controller
    {
        //加载appsetting.json
        static IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// 获取地址
        /// </summary>
        private readonly string url = configuration["FileURL:URL"];

        public INovels_BLL iNovels_BLL { get; }

        public NovelsController(INovels_BLL _iNovels_BLL)
        {
            iNovels_BLL = _iNovels_BLL;
        }
        public IActionResult Index()
        {
            ViewBag.url = url;
            return View();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="Pseudonym"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate,string novelsName="",int typeIdOne=0,int typeIdTwo=0,int pageIndex=1, int pageSize=5)
        {
            var list = iNovels_BLL.Query();
            if (!string.IsNullOrWhiteSpace(novelsName))
                list = list.Where(m => m.NovelName.Contains(novelsName)).ToList();
            if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                list = list.Where(m => m.CreateDate >= Convert.ToDateTime(startDate)).ToList();
            if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                list = list.Where(m => m.CreateDate <= Convert.ToDateTime(endDate)).ToList();
            if(typeIdOne!=0)
                list = list.Where(m => m.TypeIdOne.Equals(typeIdOne)).ToList();
            if (typeIdTwo != 0)
                list = list.Where(m => m.TypeIdTwo.Equals(typeIdTwo)).ToList();
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }
    }
}