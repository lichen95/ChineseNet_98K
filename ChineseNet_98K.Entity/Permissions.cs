using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：权限类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Permissions
    {
        public Permissions()
        {

        }

        /// <summary>
        /// Desc:权限ID
        /// Default:
        /// Nullable:False
        /// </summary>  
        [Key]
        public int PermissionId { get; set; }

        /// <summary>
        /// Desc: 权限名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string PermissionName { get; set; }

        /// <summary>
        /// Desc:  页面路径
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string URL { get; set; }

        /// <summary>
        /// Desc: 是否启用
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int IsUse { get; set; }

        /// <summary>
        /// Desc: 父级ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int PId { get; set; }

        /// <summary>
        /// Desc:  创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
