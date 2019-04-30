using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：UsersDAL接口
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public interface IAuthorUserInfo_DAL : IBase_DAL<Authors>
    {
        /// <summary>
        /// 作者信息修改
        /// </summary>
        /// <returns></returns>
        List<Authors> Query();
    }
}
