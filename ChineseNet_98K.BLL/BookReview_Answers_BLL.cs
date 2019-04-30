using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：书评回复表数据访问层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class BookReview_Answers_BLL : IBookReview_Answers_BLL
    {
        private IBookReview_Answers_DAL iBookReview_Answers_DAL;
        public BookReview_Answers_BLL(IBookReview_Answers_DAL _iBookReview_Answers_DAL)
        {
            iBookReview_Answers_DAL = _iBookReview_Answers_DAL;
        }

        /// <summary>
        /// 新增书评回复
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(BookReview_Answers t)
        {
            var result = iBookReview_Answers_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除书评回复
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iBookReview_Answers_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<BookReview_Answers> Query()
        {
            var result = iBookReview_Answers_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BookReview_Answers QueryById(int Id)
        {
            var result = iBookReview_Answers_DAL.QueryById(Id);
            return result;
        }

        public int Update(BookReview_Answers t)
        {
            throw new NotImplementedException();
        }
    }
}
