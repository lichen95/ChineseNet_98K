using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：后台用户表
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Admin_Users
    {
        public Admin_Users()
        {
            
        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>        
        [Key]
        public int Admin_UserId { get; set; }

        /// <summary>
        /// Desc:用户名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Admin_UserName { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Admin_UserPwd { get; set; }

        /// <summary>
        /// Desc:是否启用
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int State { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Desc:角色ID集合
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RoleIds { get; set; }

        /// <summary>
        /// Desc:角色名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RoleNames { get; set; }
    }
}
