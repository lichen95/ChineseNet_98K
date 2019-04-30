using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;
    /// <summary>
    /// ** 描述：审批BLL接口
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IApprovals_BLL : IBase_BLL<Approvals>
    {
        /// <summary>
        /// 审批信息
        /// </summary>
        /// <returns></returns>
        List<Approvals> Query();

        /// <summary>
        /// 修改审批
        /// </summary>
        /// <param name="Id">审批表ID</param>
        /// <param name="ApprovalMessage">审批意见</param>
        /// <returns></returns>
        int Update(int Id, int State, string ApprovalMessage, int NovelId, int ChapterId);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int Add(List<Approvals> list);
    }
}
