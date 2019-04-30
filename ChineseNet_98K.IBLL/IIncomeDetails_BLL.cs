using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IBLL
{
    using Entity;
    /// <summary>
    /// ** 描述：稿费明细表BLL层
    /// ** 创始时间：2018-12-03
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IIncomeDetails_BLL:IBase_BLL<IncomeDetails>
    {
        /// <summary>
        /// 获取明细信息
        /// </summary>
        /// <returns></returns>
        List<IncomeDetails> Query();
    }
}
