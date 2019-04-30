using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：后台用户DAL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IAdmin_Users_DAL : IBase_DAL<Admin_Users>
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        List<Admin_Users> Query();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>返回用户信息实体</returns>
        Admin_Users Login(string name, string pwd);
    }
}
