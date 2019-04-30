using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：消费记录DAL接口层
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public interface IConsumptions_DAL:IBase_DAL<Consumptions>
    {
        /// <summary>
        /// 获取消费信息
        /// </summary>
        /// <returns></returns>
        List<Consumptions> Query();
    }
}
