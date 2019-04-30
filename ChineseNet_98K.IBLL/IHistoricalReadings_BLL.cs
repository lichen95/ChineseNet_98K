using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：最近阅读
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IHistoricalReadings_BLL : IBase_BLL<HistoricalReadings>
    {
        /// <summary>
        /// 最近阅读的显示
        /// </summary>
        /// <returns></returns>
        List<HistoricalReadings> Query();
    }
}
