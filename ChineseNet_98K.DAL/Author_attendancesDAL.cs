using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// ** 描述：作者考勤BLL层
    /// ** 创始时间：2018-12-03
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Author_attendancesDAL : IAuthor_attendances_DAL
    {
        private readonly EFDbContext dbContext;
        public Author_attendancesDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增考勤记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Author_attendances t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
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
            var result = dbContext.Author_attendances.ToList();
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
