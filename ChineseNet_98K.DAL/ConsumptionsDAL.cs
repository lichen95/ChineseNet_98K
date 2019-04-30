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
    /// ** 描述：消费记录DAL层
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class ConsumptionsDAL : IConsumptions_DAL
    {
        private readonly EFDbContext dbContext;
        public ConsumptionsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 添加消费记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Consumptions t)
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
        /// 消费记录
        /// </summary>
        /// <returns></returns>
        public List<Consumptions> Query()
        {
            var result = dbContext.Consumptions.ToList();
            return result;
        }

        public Consumptions QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(Consumptions t)
        {
            throw new NotImplementedException();
        }
    }
}
