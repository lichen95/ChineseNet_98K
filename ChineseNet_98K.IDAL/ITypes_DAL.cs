using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：小说类型DAL接口
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface ITypes_DAL : IBase_DAL<Types>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>返回数据</returns>
        List<Types> Query();
    }
}
