using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;

    /// <summary>
    /// ** 描述：UsersDAL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class UsersDAL : IUsers_DAL
    {
        private readonly EFDbContext dbContext;
        public UsersDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 前台用户注册方法
        /// </summary>
        /// <param name="t">用户信息</param>
        /// <returns>int 受影响行数</returns>
        public int Add(Users t)
        {
            dbContext.Users.Add(t);
            var result = dbContext.SaveChanges();
            return t.UserId;
        }

        /// <summary>
        /// 验证手机号是否已经被占用
        /// </summary>
        /// <param name="unam">手机号</param>
        /// <returns>int 是否被占用</returns>
        public int Check(string unam)
        {
            var result = dbContext.Users.Where(m => m.Phone.Equals(unam)).Count();
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
        /// <returns>Users实体类</returns>
        public Users Login(string UserName, string UserPwd)
        {
            var result = dbContext.Users.Where(m => m.UserName.Equals(UserName) || m.Phone.Equals(UserName) || m.Email.Equals(UserName) && m.Password.Equals(UserPwd)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public List<Users> Query()
        {
            var result = dbContext.Users.ToList();
            return result;
        }

        /// <summary>
        /// 根据Id获取用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Users QueryById(int Id)
        {
            var result = dbContext.Users.Where(m => m.UserId.Equals(Id)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Users t)
        {
            Users model = dbContext.Users.Find(t.UserId);
            model.UserName = t.UserName;
            model.Email = t.Email;
            model.Address = t.Address;
            model.QQ = t.QQ;
            model.Sex = t.Sex;
            model.MyDesc = t.MyDesc;
            model.CreateDate = DateTime.Now;
            var result = dbContext.SaveChanges();
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
            Users model = dbContext.Users.Find(int.Parse(UserId));
            model.Password = Pwd;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public int UpState(int UserId)
        {
            Users model = dbContext.Users.Find(UserId);
            model.State = 1;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
