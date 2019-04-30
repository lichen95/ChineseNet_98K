using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：权限DAL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IRoles_DAL : IBase_DAL<Roles>
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        List<Roles> Query();
    }
}
