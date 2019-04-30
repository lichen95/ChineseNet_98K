using System;
using System.Collections.Generic;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// ** 描述：书评表数据访问层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class BookReviewsDAL : IBookReviews_DAL
    {
        private readonly EFDbContext dbContext;
        public BookReviewsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增书评
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(BookReviews t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除书评
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var parms = new[] {
                        new SqlParameter("@BookReviewId",Convert.ToInt32(arr[i]))
                    };
                result += dbContext.Database.ExecuteSqlCommand("exec p_DeleteBookReviews @BookReviewId", parms);
            }
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<BookReviews> Query()
        {
            var result = dbContext.BookReviews.ToList();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BookReviews QueryById(int Id)
        {
            var result = dbContext.BookReviews.Find(Id);
            return result;
        }

        public int Update(BookReviews t)
        {
            throw new NotImplementedException();
        }
    }
}
