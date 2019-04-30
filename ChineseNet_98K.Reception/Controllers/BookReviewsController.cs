using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Reception.Controllers
{
    using Entity;
    using IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：书评表业务逻辑层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class BookReviewsController : Controller
    {
        public IBookReviews_BLL iBookReviews_BLL { get; }

        public BookReviewsController(IBookReviews_BLL _iBookReviews_BLL)
        {
            iBookReviews_BLL = _iBookReviews_BLL;
        }

        /// <summary>
        /// 新增评论
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
        /// 获取评论信息
        /// </summary>
        /// <param name="novelId"></param>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(int novelId,int chapterId=0)
        {
            var result = iBookReviews_BLL.Query().Where(m=>m.NovelId.Equals(novelId)).ToList();
            if (chapterId != 0)
                result = result.Where(m => m.ChapterId.Equals(chapterId)).ToList();
            return JsonConvert.SerializeObject(result);
        }
    }
}