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
    /// <summary>
    /// ** 描述：分卷管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class VolumesController : Controller
    {
        public IVolumes_BLL iVolumes_BLL { get; }
        public VolumesController(IVolumes_BLL _iVolumes_BLL)
        {
            iVolumes_BLL = _iVolumes_BLL;
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(Volumes t)
        {
            t.CreateDate = DateTime.Now;
            var result = iVolumes_BLL.Add(t);
            return result>0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iVolumes_BLL.Delete(Ids);
            return result > 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(Volumes t)
        {
            var result = iVolumes_BLL.Update(t);
            return result > 0;
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iVolumes_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

       /// <summary>
       /// 分页查询
       /// </summary>
       /// <param name="volumeName"></param>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <returns></returns>
        [HttpPost]
        public string Query(string volumeName, int pageIndex,int pageSize)
        {
            var list = iVolumes_BLL.Query();
            if (!string.IsNullOrWhiteSpace(volumeName))
                list = list.Where(m => m.VolumeName.Contains(volumeName)).ToList();
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 根据PID查询
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryByPId(int PId)
        {
            var list = iVolumes_BLL.Query().Where(m => m.PId.Equals(PId)).ToList();
            return JsonConvert.SerializeObject(list);
        }
    }
}