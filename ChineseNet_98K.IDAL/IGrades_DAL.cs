using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：用户等级DAL接口
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IGrades_DAL : IBase_DAL<Grades>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<Grades> Query();
    }
}
