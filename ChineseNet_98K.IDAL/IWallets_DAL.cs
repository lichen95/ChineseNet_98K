using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IDAL
{
    /// <summary>
    /// ** 描述：钱包DAL接口
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    using Entity;
    public interface IWallets_DAL:IBase_DAL<Wallets>
    {
        /// <summary>
        /// 根据用户ID查询余额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Wallets GetUserid(int id);
    }
}
