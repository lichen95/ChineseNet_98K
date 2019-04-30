using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：审批DAL接口
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IApprovals_DAL : IBase_DAL<Approvals>
    {
        /// <summary>
        /// 审批信息
        /// </summary>
        /// <returns></returns>
        List<Approvals> Query();

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int Add(List<Approvals> list);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Id">审批表ID</param>
        /// <param name="State">状态</param>
        /// <param name="ApprovalMessage">审批意见</param>
        /// <param name="NovelId">小说ID</param>
        /// <param name="ChapterId">文章ID</param>
        /// <returns></returns>
        int Update(int Id, int State, string ApprovalMessage, int NovelId, int ChapterId);
    }
}
