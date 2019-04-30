using Microsoft.AspNetCore.Http;
using System;

namespace ChineseNet_98K.Reception.Content
{
    /// <summary>
    /// ** 描述：Cookie for .net core2.1 
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public static class CookieHelper
    {
        /// <summary>
        /// 设置本地cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>  
        /// <param name="minutes">过期时长，单位：分钟</param>      
        public static void SetCookies(string key, string value, int minutes = 30)
        {
            HttpContext.Current.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes),
                HttpOnly = true,// 设置为后台只读模式,前端无法通过JS来获取cookie值,可以有效的防止XXS攻击
                Secure = false,//采用安全模式来传递cookie,如果设置为true,就是当你的网站开启了SSL(就是https),的时候,这个cookie值才会被传递
                IsEssential = true//是否强制存储cookie,注意,这里的强制 是针对于上面所讲的内容的..也就是当用户不同意使用cookie的时候,你也可以通过设置这个属性为true把cookie强制存储.
                // MaxAge cookie的有效毫秒数,
                //如果设置为负值的话，则为浏览器进程Cookie(内存中保存)，关闭浏览器就失效；如果设置为0，则立即删除该Cookie。
            });
        }

        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        public static void DeleteCookies(string key)
        {
            HttpContext.Current.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        public static string GetCookies(string key)
        {
            HttpContext.Current.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }
    }
}
