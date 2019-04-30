using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IDAL;
    using IBLL;

    /// <summary>
    /// ** 描述：消费记录DAL层
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class ConsumptionsBLL:IConsumptions_BLL
    {
        private IConsumptions_DAL iConsumptions_DAL;
        public ConsumptionsBLL(IConsumptions_DAL _iConsumptions_DAL)
        {
            iConsumptions_DAL = _iConsumptions_DAL;
        }

        /// <summary>
        /// 添加消费记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Consumptions t)
        {
            var result = iConsumptions_DAL.Add(t);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 消费记录
        /// </summary>
        /// <returns></returns>
        public List<Consumptions> Query()
        {
            var result = iConsumptions_DAL.Query();
            return result;
        }

        public Consumptions QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(Consumptions t)
        {
            throw new NotImplementedException();
        }
    }
}
