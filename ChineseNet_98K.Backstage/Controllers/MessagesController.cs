using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    /// <summary>
    /// ** 描述：消息管理
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class MessagesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}