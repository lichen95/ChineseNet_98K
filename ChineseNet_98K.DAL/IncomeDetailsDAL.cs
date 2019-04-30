using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Data.SqlClient;

    /// <summary>
    /// ** 描述：稿费明细表DAL层
    /// ** 创始时间：2018-12-03
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class IncomeDetailsDAL : IIncomeDetails_DAL
    {
        private readonly EFDbContext dbContext;
        public IncomeDetailsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        /// <summary>
        /// 新增稿酬记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(IncomeDetails t)
        {
            var parms = new[] {
                new SqlParameter("@authorId",t.AuthorId),
                new SqlParameter("@NovelId",t.NovelId),
                new SqlParameter("@ProfitNum",t.ProfitNum),
                new SqlParameter("@typeId",t.Types)
            };

            var result = dbContext.Database.ExecuteSqlCommand("exec p_AddIncomeDetails @authorId,@NovelId,@ProfitNum,@typeId", parms);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public List<IncomeDetails> Query()
        {
            var result = dbContext.IncomeDetails.ToList();
            return result;
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IncomeDetails QueryById(int Id)
        {
            var result = dbContext.IncomeDetails.Find(Id);
            return result;
        }

        public int Update(IncomeDetails t)
        {
            throw new NotImplementedException();
        }
    }
}
