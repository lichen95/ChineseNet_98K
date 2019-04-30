using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：最近阅读
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class HistoricalReadingsBLL : IHistoricalReadings_BLL
    {
        private IHistoricalReadings_DAL HistoricalReadings_DAL;

        public HistoricalReadingsBLL(IHistoricalReadings_DAL _HistoricalReadings_DAL)
        {
            HistoricalReadings_DAL = _HistoricalReadings_DAL;
        }

        /// <summary>
        /// 添加最近阅读
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(HistoricalReadings t)
        {
            var result = HistoricalReadings_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除最近阅读
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = HistoricalReadings_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 最近阅读的显示
        /// </summary>
        /// <returns></returns>
        public List<HistoricalReadings> Query()
        {
            var result = HistoricalReadings_DAL.Query();
            return result;
        }

        public HistoricalReadings QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(HistoricalReadings t)
        {
            throw new NotImplementedException();
        }
    }
}
