using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：用户等级关联DAL接口
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IGrade_Users_DAL : IBase_DAL<Grade_Users>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<Grade_Users> Query();
    }
}
