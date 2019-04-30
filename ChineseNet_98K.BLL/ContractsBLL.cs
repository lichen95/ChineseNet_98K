using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：申请签约BLL层
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ContractsBLL : IContracts_BLL
    {
        private IContracts_DAL iContracts_DAL;

        public ContractsBLL(IContracts_DAL _iContracts_DAL)
        {
            iContracts_DAL = _iContracts_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Contracts t)
        {
            var result = iContracts_DAL.Add(t);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Contracts> Query()
        {
            var result = iContracts_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Contracts QueryById(int Id)
        {
            var result = iContracts_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Contracts t)
        {
            var result = iContracts_DAL.Update(t);
            return result;
        }
    }
}
