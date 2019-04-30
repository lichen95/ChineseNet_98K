using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;
    /// <summary>
    /// ** 描述：稿费明细表BLL层
    /// ** 创始时间：2018-12-03
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class IncomeDetailsBLL : IIncomeDetails_BLL
    {
        private IIncomeDetails_DAL iIncomeDetails_DAL;
        public IncomeDetailsBLL(IIncomeDetails_DAL _iIncomeDetails_DAL)
        {
            iIncomeDetails_DAL = _iIncomeDetails_DAL;
        }
        /// <summary>
        /// 新增稿酬记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(IncomeDetails t)
        {
            var result = iIncomeDetails_DAL.Add(t);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        public List<IncomeDetails> Query()
        {
            var result = iIncomeDetails_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IncomeDetails QueryById(int Id)
        {
            var result = iIncomeDetails_DAL.QueryById(Id);
            return result;
        }

        public int Update(IncomeDetails t)
        {
            throw new NotImplementedException();
        }
    }
}
