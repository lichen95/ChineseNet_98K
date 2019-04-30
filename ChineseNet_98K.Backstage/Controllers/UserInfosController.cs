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
    /// ** 描述：用户信息管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class UserInfosController : Controller
    {

        //加载appsetting.json
        static IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// 获取地址
        /// </summary>
        private static readonly string url = configuration["FileURL:URL"];

        public IUsers_BLL iUsers_BLL { get; }
        public UserInfosController(IUsers_BLL _iUsers_BLL)
        {
            iUsers_BLL = _iUsers_BLL;
        }
        public IActionResult Index()
        {
            ViewBag.url = url;
            return View();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Query(string SearchType, int pageIndex, int pageSize, string Values, DateTime? startDate, DateTime? endDate)
        {
            var list = iUsers_BLL.Query();
            var searchType = SearchType;
            var values = Values;
            switch (searchType)
            {
                case "1":
                    list = list.Where(m => m.UserName.Contains(values)).ToList();
                    break;
                case "2":
                    list = list.Where(m => m.Phone.Contains(values)).ToList();
                    break;
                case "3":
                    list = list.Where(m => m.Email.Contains(values)).ToList();
                    break;
                case "4":
                    list = list.Where(m => m.QQ.Contains(values)).ToList();
                    break;
                default:
                    list = list.ToList();
                    break;
            }
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
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iUsers_BLL.Delete(Ids);
            return result > 0;
        }

    }
}