using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.Reception.Content;
    using Entity;
    using IBLL;
    using Models;
    using Newtonsoft.Json;

    public class UsersController : Controller
    {
        /// <summary>
        /// 验证码
        /// </summary>
        private static string Codes { get; set; }

        /// <summary>
        /// 电话号
        /// </summary>
        private static string Phones { get; set; }

        private IUsers_BLL iUsers_BLL;
        private IWallets_BLL iWallets_BLL;

        public UsersController(IUsers_BLL _iUsers_BLL, IWallets_BLL _iWallets_BLL)
        {
            iUsers_BLL = _iUsers_BLL;
            iWallets_BLL = _iWallets_BLL;
        }

        /// <summary>
        /// 前台登录方法
        /// </summary>
        /// <param name="UserName">用户名/手机号/邮箱</param>
        /// <param name="UserPwd">密码</param>
        /// <returns>string 用户信息的json字符串</returns>
        [HttpPost]
        public int Login(int tye, string unam, string pwd)
        {
            if (tye == 1)
            {
                var result = iUsers_BLL.Login(unam, pwd);
                if (result != null)
                {

                    // //写入redis缓存
                    // CommonManager.CacheObj.Save<RedisCacheHelper>("key" + result.UserId, HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)),DateTime.Now.AddDays(1));

                    //var redis= HttpUtility.UrlDecode(CommonManager.CacheObj.GetCache<string, RedisCacheHelper>("key" + result.UserId));

                    //写入cookie
                    CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)), 5040);
                    //读取
                    var aa = HttpUtility.UrlDecode(CookieHelper.GetCookies("UID"));
                    return 1;
                }
                return 2;
            }
            else
            {
                var result = iUsers_BLL.Login(unam, pwd);
                if (result != null)
                {
                    //写入缓存
                    CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)), 5040);
                    return 3;
                }
                return 4;
            }
        }

        /// <summary>
        /// 获取手机短信
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public string Send(string phone, string code)
        {
            Note n = NoteHelper.SendSms(phone);
            Codes = n.Verification;
            if (n.Msg == "OK")
            {
                n.Code = 1;
                return JsonConvert.SerializeObject(n);
            }
            else
            {
                n.Code = 2302;
                return JsonConvert.SerializeObject(n);
            }
        }

        /// <summary>
        /// 前台注册方法
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>int 受影响行数</returns>
        [HttpPost]
        public string Register(string pwd, string nick)
        {
            Users t = new Users
            {
                State = 0,
                UserName = nick,
                Phone = Phones,
                Password = pwd,
                Sex = 0,
                ImgPath = "/Img/",
                CreateDate = DateTime.Now
            };
            var result = iUsers_BLL.Add(t);
            Note n = new Note();
            if (result > 0)
            {
                Wallets m = new Wallets
                {
                    Balance = 0,
                    CreateDate = DateTime.Now,
                    UserId = result
                };
                var resultAddWallet = iWallets_BLL.Add(m);
                n.Code = 1;
                n.Msg = "成功";
            }
            else
            {
                n.Code = 0;
                n.Msg = "出错啦，请重试";
            }
            return JsonConvert.SerializeObject(n);
        }

        /// <summary>
        /// 验证手机号是否已经被占用
        /// </summary>
        /// <param name="unam">手机号</param>
        /// <param name="pwd">验证码</param>
        /// <returns>int 是否被占用</returns>
        [HttpPost]
        public string Check(string unam, string pwd)
        {
            Note n = new Note();
            var result = iUsers_BLL.Check(unam);
            if (result > 0)
            {
                n.Code = 2100;
                n.Msg = "该手机号已经注册";
            }
            else
            {
                if (pwd == Codes)
                {
                    n.Code = 1;
                    n.Msg = "";
                    Phones = unam;
                }
                else
                {
                    n.Code = 2201;
                    n.Msg = "短信验证码输入错误，请重新输入";
                }
            }
            return JsonConvert.SerializeObject(n);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(Users t)
        {
            var result = iUsers_BLL.Update(t);
            return result;
        }

        /// <summary>
        /// 根据Id查询用户基本信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iUsers_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpPwd(string UserId, string Pwd)
        {
            var result = iUsers_BLL.UpPwd(UserId, Pwd);
            if (result > 0)
            {
                var model = HttpUtility.UrlDecode(CookieHelper.GetCookies("UID"));
                Users user = JsonConvert.DeserializeObject<Users>(model);
                user.Password = Pwd;
                CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(user)), 5040);
            }
            return result;
        }
    }
}