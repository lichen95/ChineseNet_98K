using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：审批信息BLL层
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ApprovalsBLL : IApprovals_BLL
    {
        private IApprovals_DAL iApprovals_DAL;
        private IMessages_DAL iMessages_DAL;
        private INovels_DAL iNovels_DAL;
        public ApprovalsBLL(IApprovals_DAL _iApprovals_DAL, IMessages_DAL _iMessages_DAL, INovels_DAL _iNovels_DAL)
        {
            iApprovals_DAL = _iApprovals_DAL;
            iMessages_DAL = _iMessages_DAL;
            iNovels_DAL = _iNovels_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Approvals t)
        {
            var result = iApprovals_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int Add(List<Approvals> list)
        {
            var result = iApprovals_DAL.Add(list);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var result = iApprovals_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回</returns>
        public List<Approvals> Query()
        {
            var result = iApprovals_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回信息</returns>
        public Approvals QueryById(int Id)
        {
            var result = iApprovals_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(int Id, int State, string ApprovalMessage, int NovelId, int ChapterId)
        {
            var result = iApprovals_DAL.Update(Id, State, ApprovalMessage, NovelId, ChapterId);
            return result;
        }

        public int Update(Approvals t)
        {
            throw new NotImplementedException();
        }
    }
}
