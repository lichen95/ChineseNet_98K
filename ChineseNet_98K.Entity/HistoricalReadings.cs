using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    ///<summary>
    ///历史纪录类
    ///</summary>
    public partial class HistoricalReadings
    {
        public HistoricalReadings()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>    
        [Key]
        public int HistoricalReadingId { get; set; }

        /// <summary>
        /// Desc:小说ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int NoveId { get; set; }

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc:章节ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int ChapterId { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Desc:书名
        /// Default:
        /// Nullable:False
        /// </summary>
        [NotMapped]
        public string NovelName { get; set; }

        /// <summary>
        /// Desc:书名
        /// Default:
        /// Nullable:False
        /// </summary>
        [NotMapped]
        public string ImgPath { get; set; }
    }
}
