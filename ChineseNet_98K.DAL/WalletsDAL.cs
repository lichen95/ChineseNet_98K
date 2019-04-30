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
    /// ** 描述：打赏功能
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class WalletsDAL : IWallets_DAL
    {
        private readonly EFDbContext dbContext;
        public WalletsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 添加纪录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Wallets t)
        {
            dbContext.Wallets.Add(t);
            var result = dbContext.SaveChanges();
            return result;
        }
        /// <summary>
        /// 根据用户id获取余额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Wallets GetUserid(int Id)
        {
            var result = dbContext.Wallets.ToList().Where(m => m.UserId.Equals(Id)).FirstOrDefault();
            return result;
        }
        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Wallets QueryById(int Id)
        {
            var result = dbContext.Wallets.Find(Id);
            return result;
        }
        /// <summary>
        /// 打赏修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Wallets t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
