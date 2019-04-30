using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ** 描述：章节表
    /// ** 创始时间：2018-11-21
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Chapters
    {
        public Chapters()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        [Key]
        public int ChapterId { get; set; }

        /// <summary>
        /// Desc:小说ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int NovelId { get; set; }

        /// <summary>
        /// Desc:正在操作的卷
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int VolumeId { get; set; }

        /// <summary>
        /// Desc:章节名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ChapterName { get; set; }

        /// <summary>
        /// Desc:章节内容
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ChapterContent { get; set; }

        /// <summary>
        /// Desc:是否VIP章节
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int IsVIP { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Desc:章节状态
        /// Default:0草稿箱  1提交/未审核  2已审核 
        /// Nullable:False
        /// </summary>           
        public int State { get; set; }

        /// <summary>
        /// Desc:作者想说
        /// Default:
        /// Nullable:False
        /// </summary>  
        public string AuthorDesc { get; set; }

        /// <summary>
        /// Desc:字数
        /// Default:
        /// Nullable:False
        /// </summary>  
        public int WordSize { get; set; }
        
        /// <summary>
        /// Desc:订单状态
        /// Default:
        /// Nullable:False
        /// </summary>  
        [NotMapped]
        public int orderStatus { get; set; }
    }
}
