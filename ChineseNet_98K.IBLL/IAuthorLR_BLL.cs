using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：作者IBLL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public interface IAuthorLR_BLL : IBase_BLL<Authors>
    {
        /// <summary>
        /// 作者注册
        /// </summary>
        /// <param name="u">实体类</param>
        /// <returns></returns>
        List<Authors> Query();

        /// <summary>
        /// 修改作者密码
        /// </summary>
        /// <param name="Aid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>a
        int Uptpwd(Authors t);

        /// <summary>
        /// 作者密码登录
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Authors AuthorLogin(string pwd, int UserId);
    }
}
