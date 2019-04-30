using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    ///订阅表
    ///</summary>
    public partial class Subscribes
    {
        public Subscribes()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>  
        [Key]
        public int SubscribeId { get; set; }

        /// <summary>
        /// Desc:小说ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int NovelId { get; set; }

        /// <summary>
        /// Desc:章节ID
        /// Default:
        /// Nullable:False
        /// </summary>      
        public int ChapterId { get; set; }

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
