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
    /// ** 描述：作者管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class AuthorsController : Controller
    {
        public IAuthorLR_BLL iAuthorLR_BLL { get; }

        public AuthorsController(IAuthorLR_BLL _iAuthorLR_BLL)
        {
            iAuthorLR_BLL = _iAuthorLR_BLL;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate,string Pseudonym,int pageIndex, int pageSize)
        {
            var list = iAuthorLR_BLL.Query();
            if (!string.IsNullOrWhiteSpace(Pseudonym))
                list = list.Where(m => m.Pseudonym.Contains(Pseudonym)).ToList();
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
            var result = iAuthorLR_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(int Id,int State)
        {
            var t = iAuthorLR_BLL.QueryById(Id);
            t.State = State;
            var result = iAuthorLR_BLL.Update(t);
            return result;
        }
    }
}