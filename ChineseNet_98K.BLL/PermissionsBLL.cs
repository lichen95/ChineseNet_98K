using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：权限BLL类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class PermissionsBLL : IPermissions_BLL
    {
        private IPermissions_DAL iPermissions_DAL;
        public PermissionsBLL(IPermissions_DAL _iPermissions_DAL)
        {
            iPermissions_DAL = _iPermissions_DAL;
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="t">权限实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Permissions t)
        {
            var result = iPermissions_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 根据用户Id获取权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Permissions> GetPermissionsByUserId(int UserId)
        {
            var result = iPermissions_DAL.GetPermissionsByUserId(UserId);
            return result;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="Ids">权限ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var result = iPermissions_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回权限</returns>
        public List<Permissions> Query()
        {
            var result = iPermissions_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取权限信息
        /// </summary>
        /// <param name="Id">权限ID</param>
        /// <returns>返回权限信息</returns>
        public Permissions QueryById(int Id)
        {
            var result = iPermissions_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Permissions t)
        {
            var result = iPermissions_DAL.Update(t);
            return result;
        }
    }
}
