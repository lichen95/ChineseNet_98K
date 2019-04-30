using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using ChineseNet_98K.Common;
    using Entity;
    using IBLL;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：用户等级管理控制器
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class Grade_UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}