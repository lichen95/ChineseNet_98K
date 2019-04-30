using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：分卷信息BLL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IVolumes_BLL : IBase_BLL<Volumes>
    {
        /// <summary>
        /// 分卷信息
        /// </summary>
        /// <returns></returns>
        List<Volumes> Query();
    }
}
