using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：钱包控制器
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class WalletsController : Controller
    {
        private IWallets_BLL wallets_bll;
        public WalletsController(IWallets_BLL _wallets_bll)
        {
            wallets_bll = _wallets_bll;
        }

        /// <summary>
        /// 根据用户id查询余额
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        [HttpPost]
        public string  GetUser(int Userid)
        {
            var result = wallets_bll.GetUserid(Userid);
            return JsonConvert.SerializeObject(result);
        }
    }
}