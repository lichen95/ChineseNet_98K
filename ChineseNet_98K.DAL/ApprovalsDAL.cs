using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;

    /// <summary>
    /// ** 描述：审批信息DAl层
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ApprovalsDAL : IApprovals_DAL
    {
        private readonly EFDbContext dbContext;
        public ApprovalsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(List<Approvals> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                dbContext.Entry(list[i]).State = EntityState.Added;
            }
            var result = dbContext.SaveChanges();
            return result;
        }

        public int Add(Approvals t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns>返回受影响行数</returns>
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
        /// 获取信息
        /// </summary>
        /// <returns>返回</returns>
        public List<Approvals> Query()
        {
            var linq = dbContext.Approvals.ToList();
            return linq;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回信息</returns>
        public Approvals QueryById(int Id)
        {
            var result = dbContext.Approvals.Find(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(int Id, int State, string ApprovalMessage, int NovelId, int ChapterId)
        {
            var parms = new[] {
                    new SqlParameter("@Id",Id),
                    new SqlParameter("@State",State),
                    new SqlParameter("@ApprovalMessage",ApprovalMessage),
                    new SqlParameter("@NovelId",NovelId),
                    new SqlParameter("@ChapterId",ChapterId)
                };
            var result = dbContext.Database.ExecuteSqlCommand("exec p_UpdateApprovals @Id,@State,@ApprovalMessage,@NovelId,@ChapterId", parms);
            return result;
        }

        public int Update(Approvals t)
        {
            throw new NotImplementedException();
        }
    }
}
