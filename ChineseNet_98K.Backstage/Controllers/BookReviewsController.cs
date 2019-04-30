using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using Entity;
    using IBLL;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：书评管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class BookReviewsController : Controller
    {
        public IBookReviews_BLL iBookReviews_BLL { get; }
        public BookReviewsController(IBookReviews_BLL _iBookReviews_BLL)
        {
            iBookReviews_BLL = _iBookReviews_BLL;
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
        public int Add(BookReviews t)
        {
            t.CreateDate = DateTime.Now;
            var result = iBookReviews_BLL.Add(t);
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
            var result = iBookReviews_BLL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Query()
        {
            var result = iBookReviews_BLL.Query();
            return JsonConvert.SerializeObject(result);
        }

    }
}