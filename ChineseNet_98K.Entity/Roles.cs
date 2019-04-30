using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：角色表
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Roles
    {
        public Roles()
        {

        }

        /// <summary>
        /// Desc:主键Id
        /// Default:
        /// Nullable:False
        /// </summary> 
        [Key]
        public int RoleId { get; set; }

        /// <summary>
        /// Desc:   角色名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RoleName { get; set; }

        /// <summary>
        /// Desc: 权限id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string PermissionIds { get; set; }

        /// <summary>
        /// Desc: 权限名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string PermissionNames { get; set; }

        /// <summary>
        /// Desc:  是否启用
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int IsUse { get; set; }

        /// <summary>
        /// Desc: 创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
