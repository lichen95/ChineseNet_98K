using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：用户角色关联表
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class User_Roles
    {
        public User_Roles()
        {

        }

        /// <summary>
        /// Desc:  主键ID
        /// Default:
        /// Nullable:False
        /// </summary>    
        [Key]
        public int User_RoleId { get; set; }

        /// <summary>
        /// Desc: 角色id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int RoleId { get; set; }

        /// <summary>
        /// Desc:  用户id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc: 创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateDate { get; set; }
    }
}
