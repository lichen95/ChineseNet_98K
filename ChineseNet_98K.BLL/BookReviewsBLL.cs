using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：书评表业务逻辑层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class BookReviewsBLL : IBookReviews_BLL
    {
        private IBookReviews_DAL iBookReviews_DAL;
        public BookReviewsBLL(IBookReviews_DAL _iBookReviews_DAL)
        {
            iBookReviews_DAL = _iBookReviews_DAL;
        }

        /// <summary>
        /// 新增书评
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(BookReviews t)
        {
            var result = iBookReviews_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除书评
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iBookReviews_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<BookReviews> Query()
        {
            var result = iBookReviews_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BookReviews QueryById(int Id)
        {
            var result = iBookReviews_DAL.QueryById(Id);
            return result;
        }

        public int Update(BookReviews t)
        {
            throw new NotImplementedException();
        }
    }
}
