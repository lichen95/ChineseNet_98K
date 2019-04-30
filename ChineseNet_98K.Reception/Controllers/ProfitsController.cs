using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.IBLL;
    /// <summary>
    /// ** 描述：稿费记录控制器
    /// ** 创始时间：2018-12-2
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ProfitsController : Controller
    {
        public IProfits_BLL iProfits_BLL { get; set; }

        public ProfitsController(IProfits_BLL _iProfits_BLL)
        {
            iProfits_BLL = _iProfits_BLL;
        }
    }
}