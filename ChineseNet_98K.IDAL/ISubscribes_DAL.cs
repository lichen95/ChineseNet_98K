using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：VIP章节订阅DAL接口
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface ISubscribes_DAL:IBase_DAL<Subscribes>
    {
        /// <summary>
        /// 获取订阅信息
        /// </summary>
        /// <returns></returns>
        List<Subscribes> Query();
    }
}
