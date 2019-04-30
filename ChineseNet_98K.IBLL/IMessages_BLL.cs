using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：站内消息BLL接口
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public interface IMessages_BLL : IBase_BLL<Messages>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<Messages> Query();
    }
}
