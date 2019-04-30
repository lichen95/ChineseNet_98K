using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：书评表
    /// ** 创始时间：2018-11-21
    /// ** 修改时间：2018-11-26
    /// ** 作者：lc
    /// </summary>
    public partial class BookReviews
    {
        public BookReviews()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>  
        [Key]
        public int BookReviewId { get; set; }

        /// <summary>
        /// Desc:书号
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
        /// Desc:评论内容
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string BookReviewContent { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
