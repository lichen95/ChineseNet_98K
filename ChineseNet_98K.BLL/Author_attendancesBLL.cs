using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IDAL;
    using IBLL;
    using System.Linq;

    /// <summary>
    /// ** 描述：作者考勤BLL层
    /// ** 创始时间：2018-12-03
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Author_attendancesBLL : IAuthor_attendances_BLL
    {
        private IAuthor_attendances_DAL iAuthor_attendances_DAL;
        public Author_attendancesBLL(IAuthor_attendances_DAL _iAuthor_attendances_DAL)
        {
            iAuthor_attendances_DAL = _iAuthor_attendances_DAL;
        }
        /// <summary>
        /// 新增考勤记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Author_attendances t)
        {
            var result = iAuthor_attendances_DAL.Add(t);
            return result;
        }
        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Author_attendances> Query()
        {
            var result = iAuthor_attendances_DAL.Query();
            return result;
        }

        public Author_attendances QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(Author_attendances t)
        {
            throw new NotImplementedException();
        }
    }
}
