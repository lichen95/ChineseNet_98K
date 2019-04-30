using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：用户等级表
    /// ** 创始时间：2018-11-21
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public partial class Grades
    {
        public Grades()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        [Key]
        public int GradeId { get; set; }

        /// <summary>
        /// Desc:等级名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GradeName { get; set; }

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
