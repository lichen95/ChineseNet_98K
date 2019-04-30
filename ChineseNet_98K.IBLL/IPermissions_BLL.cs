using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：权限BLL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IPermissions_BLL : IBase_BLL<Permissions>
    {
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        List<Permissions> Query();

        /// <summary>
        /// 根据用户Id获取权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Permissions> GetPermissionsByUserId(int UserId);
    }
}
