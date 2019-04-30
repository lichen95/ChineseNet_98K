using System;
using System.Collections.Generic;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// ** 描述：书评回复表数据访问层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class BookReview_Answers_DAL : IBookReview_Answers_DAL
    {
        private readonly EFDbContext dbContext;
        public BookReview_Answers_DAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增书评回复
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(BookReview_Answers t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除书评回复
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
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

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<BookReview_Answers> Query()
        {
            var result = dbContext.BookReview_Answers.ToList();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BookReview_Answers QueryById(int Id)
        {
            var result = dbContext.BookReview_Answers.Find(Id);
            return result;
        }

        public int Update(BookReview_Answers t)
        {
            throw new NotImplementedException();
        }
    }
}
