using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：WalletsBLL
    /// ** 创始时间：2018-12-4
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class WalletsBLL : IWallets_BLL
    {
        private IWallets_DAL iWallets_DAL;
        public WalletsBLL(IWallets_DAL _iWallets_DAL)
        {
            iWallets_DAL = _iWallets_DAL;
        }

        /// <summary>
        /// 添加纪录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Wallets t)
        {
            var result = iWallets_DAL.Add(t);
            return result;
        }
        /// <summary>
        /// 根据用户id获取余额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Wallets GetUserid(int id)
        {
            var result = iWallets_DAL.GetUserid(id);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }      

        public Wallets QueryById(int Id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打赏修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Wallets t)
        {
            var result = iWallets_DAL.Update(t);
            return result;
        }
      
    }
}
