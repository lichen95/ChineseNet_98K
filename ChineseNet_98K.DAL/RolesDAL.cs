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
    /// ** 描述：角色DAL类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class RolesDAL : IRoles_DAL
    {
        private readonly EFDbContext dbContext;
        public RolesDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Roles t)
        {
            var parm = new[] {
                new SqlParameter("@RoleName",t.RoleName),
                new SqlParameter("@PermissionIds",t.PermissionIds),
                new SqlParameter("@PermissionNames",t.PermissionNames),
                new SqlParameter("@IsUse",t.IsUse),
                new SqlParameter("@CreateDate",t.CreateDate),
                new SqlParameter("@rowCount",SqlDbType.Int)
            };
            parm[5].Direction = ParameterDirection.Output;
            var result = dbContext.Database.ExecuteSqlCommand("exec p_AddRoles  @RoleName, @PermissionIds,@PermissionNames,@IsUse,@CreateDate,0", parm);
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
                        new SqlParameter("@id",Convert.ToInt32(arr[i]))
                };
                result += dbContext.Database.ExecuteSqlCommand("exec p_DeleteRoles  @id", parm);
            }
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回list</returns>
        public List<Roles> Query()
        {
            var result = dbContext.Roles.ToList();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">权限ID</param>
        /// <returns>返回信息</returns>
        public Roles QueryById(int Id)
        {
            var result = dbContext.Roles.Find(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Roles t)
        {
            var parm = new[] {
                new SqlParameter("@RoleId",t.RoleId),
                new SqlParameter("@RoleName",t.RoleName),
                new SqlParameter("@PermissionIds",t.PermissionIds),
                new SqlParameter("@PermissionNames",t.PermissionNames),
                new SqlParameter("@IsUse",t.IsUse),
                new SqlParameter("@CreateDate",t.CreateDate),
                new SqlParameter("@rowCount",SqlDbType.Int)
            };
            parm[6].Direction = ParameterDirection.Output;
            var result = dbContext.Database.ExecuteSqlCommand("exec p_UpdateRoles  @RoleId,@RoleName, @PermissionIds,@PermissionNames,@IsUse,@CreateDate,0", parm);
            return result;
        }
    }
}
