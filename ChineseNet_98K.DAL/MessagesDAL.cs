using System;
using System.Collections.Generic;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// ** 描述：我的消息DAL层
    /// ** 创始时间：2018-11-23
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class MessagesDAL : IMessages_DAL
    {

        private readonly EFDbContext dbContext;
        public MessagesDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Messages t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除
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
        public List<Messages> Query()
        {
            var result = dbContext.Messages.ToList();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Messages QueryById(int Id)
        {
            var result = dbContext.Messages.Find(Id);
            return result;
        }

        public int Update(Messages t)
        {
            throw new NotImplementedException();
        }
    }
}
