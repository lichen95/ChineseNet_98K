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
    /// ** 描述：稿费(收益表)DAL层
    /// ** 创始时间：2018-12-2
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ProfitsDAL : IProfits_DAL
    {
        private readonly EFDbContext dbContext;
        public ProfitsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增稿费记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Profits t)
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
        public List<Profits> Query()
        {
            var result = dbContext.Profits.ToList();
            return result;
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Profits QueryById(int Id)
        {
            var result = dbContext.Profits.Find(Id);
            return result;
        }

        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Profits t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
