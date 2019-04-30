using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using Entity;
    using IBLL;
    using Common;
    using Newtonsoft.Json;
    using System.Web;
    using ChineseNet_98K.Backstage.wwwroot;
    /// <summary>
    /// ** 描述：后台登录
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>

    public class AdminController : Controller
    {
        public IAdmin_Users_BLL iAdmin_Users_BLL { get; }
        public IPermissions_BLL iPermissions_BLL { get; }
        public AdminController(IAdmin_Users_BLL _iAdmin_Users_BLL, IPermissions_BLL _iPermissions_BLL)
        {
            iAdmin_Users_BLL = _iAdmin_Users_BLL;
            iPermissions_BLL = _iPermissions_BLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string UserName, string UserPwd)
        {
            var pwd = Md5Helper.MD5Encoding(UserPwd, 123);
            var result = iAdmin_Users_BLL.Login(UserName, pwd);
            if (result != null)
            {
                //FormsAuthentication.SetAuthCookie(UserName, false); 
                //写入缓存
                CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)),30);
               // CacheHelper.SetCacheValue("Uid", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)));
               //  var s = CacheHelper.GetCacheValue("Uid");
               //var aa= CookieHelper.GetCookies("UID");
                return Redirect("~/Admin/Index?Id="+ result.Admin_UserId);
            }
            return Redirect("~/Admin/Login");
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }

        /// <summary>
        /// 根据用户ID获取权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetPermissionsByAdmin_UserId(int Id)
        {
            var result = iPermissions_BLL.GetPermissionsByUserId(Id).Where(m => m.PId.Equals(0));
           return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 根据PID加载二级菜单
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetPermissionsByPId(int PId)
        {
            var result = iPermissions_BLL.Query().Where(m => m.PId.Equals(PId)).ToList();
            return JsonConvert.SerializeObject(result);
        }

    }
}