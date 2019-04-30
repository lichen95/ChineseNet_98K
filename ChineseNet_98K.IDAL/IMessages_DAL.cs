using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：站内消息DAL接口
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public interface IMessages_DAL : IBase_DAL<Messages>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<Messages> Query();
    }
}
