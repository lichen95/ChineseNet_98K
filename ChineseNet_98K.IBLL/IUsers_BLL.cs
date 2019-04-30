using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：UsersBLL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IUsers_BLL : IBase_BLL<Users>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        List<Users> Query();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        Users Login(string UserName, string UserPwd);

        /// <summary>
        /// 检测是否已有该账号
        /// </summary>
        /// <param name="unam"></param>
        /// <returns></returns>
        int Check(string unam);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        int UpPwd(string UserId, string Pwd);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        int UpState(int UserId);
    }
}
