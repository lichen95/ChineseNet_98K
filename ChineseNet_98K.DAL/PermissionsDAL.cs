using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlClient;

    /// <summary>
    /// ** 描述：权限DAL类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class PermissionsDAL : IPermissions_DAL
    {
        private readonly EFDbContext dbContext;
        public PermissionsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="t">权限实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Permissions t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="Ids">权限ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            List<Permissions> list = new List<Permissions>();
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var t = QueryById(Convert.ToInt32(arr[i]));
                dbContext.Entry(t).State = EntityState.Deleted;
                result += dbContext.SaveChanges();
            }
            return result;
        }

        /// <summary>
        /// 根据用户Id获取权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Permissions> GetPermissionsByUserId(int UserId)
        {
            var sql = @"select p.* from Permissions p join Permission_Roles pr on p.PermissionId= pr.PermissionId join Roles r on pr.RoleId = r.RoleId join User_Roles ur on r.RoleId = ur.RoleId join Admin_Users u on u.Admin_UserId = ur.UserId where u.Admin_UserId =@UserId";
            var parm = new[] {
                    new SqlParameter("@UserId",UserId)
                };
            var getPermissions = dbContext.Permissions.FromSql(sql, parm).ToList();
            return getPermissions;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回权限</returns>
        public List<Permissions> Query()
        {
            var result = dbContext.Permissions.ToList();
            return result;
        }

        /// <summary>
        /// 根据Id获取权限信息
        /// </summary>
        /// <param name="Id">权限ID</param>
        /// <returns>返回权限信息</returns>
        public Permissions QueryById(int Id)
        {
            var result = dbContext.Permissions.Find(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Permissions t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
