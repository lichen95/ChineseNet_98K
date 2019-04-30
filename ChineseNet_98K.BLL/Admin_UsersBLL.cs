using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：用户BLL类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Admin_UsersBLL : IAdmin_Users_BLL
    {
        private IAdmin_Users_DAL IAdmin_Users_DAL;
        public Admin_UsersBLL(IAdmin_Users_DAL _IAdmin_Users_DAL)
        {
            IAdmin_Users_DAL = _IAdmin_Users_DAL;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>返回用户信息实体</returns>
        public Admin_Users Login(string name, string pwd)
        {
            var result = IAdmin_Users_DAL.Login(name, pwd);
            return result;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Admin_Users t)
        {
            var result = IAdmin_Users_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var result = IAdmin_Users_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回list</returns>
        public List<Admin_Users> Query()
        {
            var result = IAdmin_Users_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">权限ID</param>
        /// <returns>返回信息</returns>
        public Admin_Users QueryById(int Id)
        {
            var result = IAdmin_Users_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Admin_Users t)
        {
            var result = IAdmin_Users_DAL.Update(t);
            return result;
        }
    }
}
