using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：UsersDAL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public interface IAuthorLR_DAL : IBase_DAL<Authors>
    {
        /// <summary>
        /// 获取作者信息
        /// </summary>
        /// <returns></returns>
        List<Authors> Query();

        /// <summary>
        /// 修改作者密码
        /// </summary>
        /// <param name="Aid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        int Uptpwd(Authors t);

        /// <summary>
        /// 作者登录
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Authors AuthorLogin(string pwd, int UserId);
    }
}
