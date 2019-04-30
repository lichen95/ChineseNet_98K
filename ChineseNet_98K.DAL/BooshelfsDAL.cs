using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Common;
    using Microsoft.EntityFrameworkCore;
    /// <summary>
    /// ** 描述：我的书架
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class BooshelfsDAL : IBooshelfs_DAL
    {

        private readonly EFDbContext dbContext;
        public BooshelfsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        /// <summary>
        /// 我的书架添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Booshelfs t)
        {
            try
            {
                dbContext.Booshelfs.Add(t);
                var result = dbContext.SaveChanges();
                return result;
            }
            catch (Exception )
            {
                return 0;
            }
        }
        /// <summary>
        /// 删除书架
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            try
            {
                var arr = Ids.Split(',');
                var result = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    var t = QueryById(Convert.ToInt32(arr[i]));
                    dbContext.Entry(t).State = EntityState.Deleted;
                    result += dbContext.SaveChanges();
                }
                return result;
            }
            catch (Exception )
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据Id查询到信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Booshelfs QueryById(int Id)
        {
            var result = dbContext.Booshelfs.Where(m => m.BookshelfId.Equals(Id)).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 修改书架的信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Booshelfs t)
        {
            try
            {
                Booshelfs booshelfs = dbContext.Booshelfs.Find(t.BookshelfId);
                booshelfs.BookshelfId=t.BookshelfId;
                booshelfs.NovelId = t.NovelId;
                booshelfs.UserId = t.UserId;
                booshelfs.CreateDate = DateTime.Now;
                booshelfs.BookshelfGroupId = t.BookshelfGroupId;
                booshelfs.TypeName = t.TypeName;
                booshelfs.NovelName = t.NovelName;
                booshelfs.Name = t.Name;
                booshelfs.ChapterName = t.ChapterName;
                booshelfs.Time = t.Time;
                var result = dbContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 书架的显示
        /// </summary>
        /// <returns></returns>
        public List<Booshelfs> Query()
        {
            try
            {
                var result = from b in dbContext.Booshelfs.ToList()
                             join n in dbContext.Novels.ToList() on
                             b.NovelId equals n.NovelId
                             join a in dbContext.Authors.ToList() on
                             n.AuthorId equals a.AuthorId
                             join u in dbContext.Users.ToList() on
                             b.UserId equals u.UserId
                             join t in dbContext.Types.ToList()on
                             n.TypeIdOne equals t.TypeId
                             join b1 in dbContext.BookshelfGroups.ToList() on
                             b.BookshelfGroupId equals b1.BookshelfGroupId
                             select new Booshelfs
                             {
                                 BookshelfId = b.BookshelfId,
                                 NovelId = b.NovelId,
                                 UserId=b.UserId,
                                 CreateDate=b.CreateDate,
                                 BookshelfGroupId=b.BookshelfGroupId,
                                 TypeName = t.TypeName,
                                 NovelName = n.NovelName,
                                 Name = a.Name
                             };
                
                return result.ToList();
            }
            catch (Exception )
            {
                return null;
            }
        }


        #region  书签

        /// <summary>
        /// 我的书签的添加
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddBookmarks(Bookmarks book)
        {
            try
            {
                dbContext.Bookmarks.Add(book);
                var result = dbContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 书签的修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateBookmarks(int BId,int UserId, int NovelId, int ChapterId)
        {
            try
            {
                Bookmarks boo = dbContext.Bookmarks.Find(BId);
               
                boo.NovelId = NovelId;
                boo.UserId = UserId;
                boo.ChapterId = ChapterId;
                boo.CreateDate = DateTime.Now;
                var result = dbContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 根据Id查询书签信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Bookmarks QueryByIdBookmarks(int UserId, int NovelId)
        {
            try
            {
                var result = dbContext.Bookmarks.Where(m => m.NovelId.Equals(NovelId)&& m.UserId.Equals(UserId)).FirstOrDefault();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion
    }
}
