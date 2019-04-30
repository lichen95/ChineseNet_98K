using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IDAL;
    using IBLL;

    /// <summary>
    /// ** 描述：稿费(收益表)DAL层
    /// ** 创始时间：2018-12-2
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ProfitsBLL:IProfits_BLL
    {
        private IProfits_DAL iProfits_DAL;
        public ProfitsBLL(IProfits_DAL _iProfits_DAL)
        {
            iProfits_DAL = _iProfits_DAL;
        }

        /// <summary>
        /// 新增稿费记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Profits t)
        {
            var result = iProfits_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iProfits_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Profits> Query()
        {
            var result = iProfits_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Profits QueryById(int Id)
        {
            var result = iProfits_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Profits t)
        {
            var result = iProfits_DAL.Update(t);
            return result;
        }
    }
}
