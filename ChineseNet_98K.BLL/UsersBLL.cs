using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：UsersDAL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class UsersBLL : IUsers_BLL
    {
        private IUsers_DAL iUsers_DAL;
        public UsersBLL(IUsers_DAL _iUsers_DAL)
        {
            iUsers_DAL = _iUsers_DAL;
        }

        /// <summary>
        /// 前台用户注册方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns>int 受影响行数</returns>
        public int Add(Users t)
        {
            var result = iUsers_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 验证手机号是否已经被占用
        /// </summary>
        /// <param name="name">手机号</param>
        /// <returns>int 是否被占用</returns>
        public int Check(string unam)
        {
            var result = iUsers_DAL.Check(unam);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 前台用户登录方法
        /// </summary>
        /// <param name="UserName">用户名/手机号/邮箱</param>
        /// <param name="UserPwd">密码</param>
        /// <returns>Users 实体</returns>
        public Users Login(string UserName, string UserPwd)
        {
            var result = iUsers_DAL.Login(UserName, UserPwd);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Users> Query()
        {
            var result = iUsers_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Users QueryById(int Id)
        {
            var result = iUsers_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Users t)
        {
            var result = iUsers_DAL.Update(t);
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public int UpPwd(string UserId, string Pwd)
        {
            var result = iUsers_DAL.UpPwd(UserId, Pwd);
            return result;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int UpState(int UserId)
        {
            var result = iUsers_DAL.UpState(UserId);
            return result;
        }
    }
}
