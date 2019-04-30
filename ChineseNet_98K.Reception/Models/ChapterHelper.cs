using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseNet_98K.Reception.Models
{
    /// <summary>
    /// ** 描述：章节帮助类
    /// ** 创始时间：2018-12-7
    /// ** 修改时间：-
    /// ** 作者：mqc
    /// </summary>
    public class ChapterHelper
    {
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

        /// <summary>
        /// 排序
        /// </summary>
        public Int64 rowId { get; set; }
    }
}
