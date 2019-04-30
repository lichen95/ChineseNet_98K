using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：书评回复表
    /// ** 创始时间：2018-11-21
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class BookReview_Answers
    {
        public BookReview_Answers()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>  
        [Key]
        public int BookReview_AnswerId { get; set; }

        /// <summary>
        /// Desc:书评ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        public int BookReviewId { get; set; }

        /// <summary>
        /// Desc:评论内容
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string BookReview_AnswerContent { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
