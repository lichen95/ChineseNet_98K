using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：申请签约BLL接口
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IContracts_BLL : IBase_BLL<Contracts>
    {
        /// <summary>
        /// 获取申请签约信息
        /// </summary>
        /// <returns></returns>
        List<Contracts> Query();
    }
}
