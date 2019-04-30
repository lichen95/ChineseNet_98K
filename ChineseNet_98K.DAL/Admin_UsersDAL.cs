using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// ** 描述：用户DAL类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Admin_UsersDAL : IAdmin_Users_DAL
    {
        private readonly EFDbContext dbContext;
        public Admin_UsersDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Admin_Users t)
        {
            var parm = new[] {
                        new SqlParameter("@Admin_UserName",t.Admin_UserName),
                        new SqlParameter("@Admin_UserPwd",t.Admin_UserPwd),
                        new SqlParameter("@State",t.State),
                        new SqlParameter("@CreateDate",t.CreateDate),
                         new SqlParameter("@RoleIds",t.RoleIds),
                        new SqlParameter("@RoleNames",t.RoleNames),
                         new SqlParameter("@rowCount",SqlDbType.Int)
                    };
            parm[6].Direction = ParameterDirection.Output;
            var result = dbContext.Database.ExecuteSqlCommand("exec p_AddUsers  @Admin_UserName, @Admin_UserPwd,@State,@CreateDate,@RoleIds,@RoleNames,0", parm);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var t = QueryById(Convert.ToInt32(arr[i]));
                var parm = new[] {
                        new SqlParameter("@Admin_UserId",Convert.ToInt32(arr[i]))
                        };
                result += dbContext.Database.ExecuteSqlCommand("exec p_DeleteUsers  @Admin_UserId", parm);
            }
            return result;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>返回用户信息实体</returns>
        public Admin_Users Login(string name, string pwd)
        {
            var result = dbContext.Admin_Users.Where(m => m.Admin_UserName.Equals(name) && m.Admin_UserPwd.Equals(pwd)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回list</returns>
        public List<Admin_Users> Query()
        {
            var result = dbContext.Admin_Users.ToList();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">权限ID</param>
        /// <returns>返回信息</returns>
        public Admin_Users QueryById(int Id)
        {
            var result = dbContext.Admin_Users.Find(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Admin_Users t)
        {
            var parm = new[] {
                            new SqlParameter("@Admin_UserId",t.Admin_UserId),
                    new SqlParameter("@Admin_UserName",t.Admin_UserName),
                    new SqlParameter("@Admin_UserPwd",t.Admin_UserPwd),
                    new SqlParameter("@State",t.State),
                    new SqlParameter("@CreateDate",t.CreateDate),
                        new SqlParameter("@RoleIds",t.RoleIds),
                    new SqlParameter("@RoleNames",t.RoleNames),
                        new SqlParameter("@rowCount",SqlDbType.Int)
                };
            parm[7].Direction = ParameterDirection.Output;
            var result = dbContext.Database.ExecuteSqlCommand("exec p_UpdateUsers  @Admin_UserId,@Admin_UserName, @Admin_UserPwd,@State,@CreateDate,@RoleIds,@RoleNames,0", parm);
            return result;
        }
    }
}
