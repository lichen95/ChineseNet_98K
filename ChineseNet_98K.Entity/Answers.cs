using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    /// 答案表
    ///</summary>
    public partial class Answers
    {
        public Answers()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        [Key]
        public int AnswerId { get; set; }

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc:我的答案
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MyAnswer { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
