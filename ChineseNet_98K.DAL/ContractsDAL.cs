using System;
using System.Collections.Generic;

namespace ChineseNet_98K.DAL
{
    using ChineseNet_98K.IDAL;
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// ** 描述：申请签约DAL层
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ContractsDAL : IContracts_DAL
    {
        private readonly EFDbContext dbContext;
        public ContractsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Contracts t)
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
        public List<Contracts> Query()
        {
            var linq = from s in dbContext.Contracts.ToList()
                       join
                       c in dbContext.Authors.ToList() on
                       s.AuthorId equals c.AuthorId
                       select new Contracts
                       {
                           ContractId = s.ContractId,
                           CreateDate = s.CreateDate,
                           AuthorId = s.AuthorId,
                           Name = c.Pseudonym,
                           State = s.State
                       };
            return linq.ToList();
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Contracts QueryById(int Id)
        {
            var result = dbContext.Contracts.Find(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Contracts t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
