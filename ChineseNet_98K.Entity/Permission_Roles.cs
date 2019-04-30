using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：权限角色关联表
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Permission_Roles
    {
        public Permission_Roles()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>  
        [Key]
        public int Permission_RoleId { get; set; }

        /// <summary>
        /// Desc: 权限ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int PermissionId { get; set; }

        /// <summary>
        /// Desc: 角色ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int RoleId { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
