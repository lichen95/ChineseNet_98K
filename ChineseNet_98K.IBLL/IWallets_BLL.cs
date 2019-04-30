using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IBLL
{
    /// <summary>
    /// ** 描述：钱包BLL接口
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    using Entity;
    public interface IWallets_BLL : IBase_BLL<Wallets>
    {
        /// <summary>
        /// 根据用户id查询余额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Wallets GetUserid(int id);
    }
}
