using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// ** 描述：订阅章节DAL层
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>

    public class SubscribesDAL : ISubscribes_DAL
    {
        private readonly EFDbContext dbContext;
        public SubscribesDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 订阅章节
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Subscribes t)
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
        public List<Subscribes> Query()
        {
            var result = dbContext.Subscribes.ToList();
            return result;
        }

        public Subscribes QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(Subscribes t)
        {
            throw new NotImplementedException();
        }
    }
}
