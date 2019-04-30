using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    ///安全问题
    ///</summary>
    public partial class SafetyProblems
    {
        public SafetyProblems()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary> 
        [Key]
        public int SafetyProblemId { get; set; }

        /// <summary>
        /// Desc:用户安全问题
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string SafetyProblemName { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
