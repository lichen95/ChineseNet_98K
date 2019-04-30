using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using ChineseNet_98K.Common;
    using Entity;
    using IBLL;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：等级管理控制器
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class GradesController : Controller
    {
        public IGrades_BLL iGrades_BLL { get; }

        public GradesController(IGrades_BLL _iGrades_BLL)
        {
            iGrades_BLL = _iGrades_BLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int Add(Grades t)
        {
            t.CreateDate = DateTime.Now;
            var result = iGrades_BLL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public int Delete(string Ids)
        {
            var result = iGrades_BLL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 5)
        {
            var list = iGrades_BLL.Query();
            if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                list = list.Where(m => m.CreateDate >= Convert.ToDateTime(startDate)).ToList();
            if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                list = list.Where(m => m.CreateDate <= Convert.ToDateTime(endDate)).ToList();
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iGrades_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(Grades t)
        {
            var result = iGrades_BLL.Update(t);
            return result;
        }
    }
}