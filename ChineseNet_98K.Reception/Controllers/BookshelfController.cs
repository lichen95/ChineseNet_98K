using Microsoft.AspNetCore.Mvc;
using System;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.Entity;
    using ChineseNet_98K.IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：书架信息控制器
    /// ** 创始时间：2018-12-2
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class BookshelfController : Controller
    {
        private IBooshelf_BLL Booshelf_BLL;
        private IHistoricalReadings_BLL historicalReadings_BLL;
        public BookshelfController(IBooshelf_BLL _Booshelf_BLL, IHistoricalReadings_BLL _historicalReadings_BLL)
        {
            Booshelf_BLL = _Booshelf_BLL;
            historicalReadings_BLL = _historicalReadings_BLL;
        }

        /// <summary>
        /// 添加书架
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddBookshelf(int uid, int nid)
        {
            Booshelfs b = new Booshelfs
            {
                NovelId = nid,
                UserId = uid,
                CreateDate = DateTime.Now,
                BookshelfGroupId = 2
            };
            var result = Booshelf_BLL.Add(b);
            return result;
        }

        /// <summary>
        /// 删除书架
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int DelBookshelf(string Ids)
        {
            var result = Booshelf_BLL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 显示书架
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string QueryBookshelf(int Uid,int Bid)
        {
            var result = Booshelf_BLL.Query(Uid,Bid);
            return JsonConvert.SerializeObject(result);
        }

        #region   最近阅读
        /// <summary>
        /// 添加最近阅读
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddRead(int uid, int nid)
        {
            HistoricalReadings h = new HistoricalReadings
            {
                CreateDate = DateTime.Now,
                UserId = uid,
                NoveId = nid,
                ChapterId = 1
            };
            var result = historicalReadings_BLL.Add(h);
            return result;
        }

        /// <summary>
        /// 删除最近阅读
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int DelRead(string Ids)
        {
            var result = historicalReadings_BLL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 显示最近阅读
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string QueryRead()
        {
            var result = historicalReadings_BLL.Query();
            return JsonConvert.SerializeObject(result);
        }
        #endregion

        #region  书签的添加
        public int AddBookmarks(int uid, int nid, int cid, int BId)
        {
            var boo = Booshelf_BLL.QueryByIdBookmarks(uid, nid);
            if (boo == null)
            {
                Bookmarks book = new Bookmarks
                {
                    NovelId = nid,
                    UserId = uid,
                    ChapterId = cid,
                    CreateDate = DateTime.Now
                };
                var result = Booshelf_BLL.AddBookmarks(book);
                return result;
            }
            else
            {
                var result = Booshelf_BLL.UpdateBookmarks(BId, uid, nid, cid);
                return result;
            }
        }
        #endregion
    }
}