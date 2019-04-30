using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;
    /// <summary>
    /// ** 描述：我的书架
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class BooshelfsBLL : IBooshelf_BLL
    {
        private IBooshelfs_DAL booshelfs_DAL;
        private INovels_DAL novels_DAL;
        private IChapters_DAL chapters_DAL;
        public BooshelfsBLL(IBooshelfs_DAL _booshelfs_DAL,INovels_DAL _novels_DAL, IChapters_DAL _chapters_DAL)
        {
            booshelfs_DAL = _booshelfs_DAL;
            novels_DAL= _novels_DAL;
            chapters_DAL = _chapters_DAL;
        }
        /// <summary>
        /// 添加书架
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Booshelfs t)
        {
            var result = booshelfs_DAL.Add(t);
            return result;
        }


        /// <summary>
        /// 删除书架
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = booshelfs_DAL.Delete(Ids);
            return result;
        }
        /// <summary>
        /// 显示书架
        /// </summary>
        /// <returns></returns>
        public List<Booshelfs> Query(int Uid, int Bid)
        {
            var result = booshelfs_DAL.Query().Where(b=>b.BookshelfGroupId.Equals(Bid)&&b.UserId.Equals(Uid)).ToList();
            List<Booshelfs> li = new List<Booshelfs>();
            foreach (var item in result)
            {
                List<Chapters> list = chapters_DAL.Query(item.NovelId).OrderByDescending(m => m.CreateDate).ToList();
                if (list.Count != 0)
                {
                    item.Time = list.FirstOrDefault().CreateDate;
                    item.ChapterName = list.FirstOrDefault().ChapterName;
                    li.Add(item);
                }
            }
            return li;
        }

        public Booshelfs QueryById(int Id)
        {
            throw new NotImplementedException();
        }



        public int Update(Booshelfs t)
        {
            throw new NotImplementedException();
        }

        #region  书签
        /// <summary>
        /// 书签的添加
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddBookmarks(Bookmarks book)
        {
            var result = booshelfs_DAL.AddBookmarks(book);
            return result;
        }
        /// <summary>
        /// 根据I的查询书签的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Bookmarks QueryByIdBookmarks(int UserId, int NovelId)
        {
            var result = booshelfs_DAL.QueryByIdBookmarks(UserId, NovelId);
            return result;
        }
        /// <summary>
        /// 修改书签信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int UpdateBookmarks(int BId, int UserId, int NovelId, int ChapterId)
        {
            var result = booshelfs_DAL.UpdateBookmarks(BId, UserId, NovelId, ChapterId);
            return result;
        }
        #endregion

    }
}
