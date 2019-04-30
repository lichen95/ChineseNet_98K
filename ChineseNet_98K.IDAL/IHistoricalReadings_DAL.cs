using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：最近阅读
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IHistoricalReadings_DAL : IBase_DAL<HistoricalReadings>
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        List<HistoricalReadings> Query();
    }
}
