using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：用户等级关联表
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class Grade_Users
    {
        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>      
        [Key]
        public int Grade_UserId { get; set; }

        /// <summary>
        /// Desc:用户id
        /// Default:
        /// Nullable:False
        /// </summary>      
        public int UserId { get; set; }

        /// <summary>
        /// Desc:经验值
        /// Default:
        /// Nullable:False
        /// </summary>      
        public int Experience { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>      
        public DateTime CreateDate { get; set; }
    }
}
