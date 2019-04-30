using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ** 描述：小说信息类
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Novels
    {
        public Novels()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>    
        [Key]
        public int NovelId { get; set; }

        /// <summary>
        /// Desc:书号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string NovelNum { get; set; }

        /// <summary>
        /// Desc:书名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string NovelName { get; set; }

        /// <summary>
        /// Desc:作者ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int AuthorId { get; set; }

        /// <summary>
        /// Desc:简介
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string NovelDesc { get; set; }

        /// <summary>
        /// Desc:标签
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string LabelName { get; set; }

        /// <summary>
        /// Desc:封面路径
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ImgPath { get; set; }

        /// <summary>
        /// Desc:作者寄语
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string AuthorMessage { get; set; }

        /// <summary>
        /// Desc:类型ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int TypeIdOne { get; set; }

        /// <summary>
        /// Desc:类型ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int TypeIdTwo { get; set; }

        /// <summary>
        /// Desc:状态
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int State { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Desc:总字数
        /// Default:
        /// Nullable:False
        /// </summary>        
        public int WordSize { get; set; }

        /// <summary>
        /// Desc:类型名称1
        /// Default:
        /// Nullable:False
        /// </summary>
        [NotMapped]
        public string TypeNameOne { get; set; }

        /// <summary>
        /// Desc:类型名称2
        /// Default:
        /// Nullable:False
        /// </summary>
        [NotMapped]
        public string TypeNameTwo { get; set; }

        /// <summary>
        /// Desc:用户名称
        /// Default:
        /// Nullable:False
        /// </summary>
        [NotMapped]
        public string UserName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [NotMapped]
        public DateTime NewTime { get; set; }

        /// <summary>
        /// 最新章节
        /// </summary>
        [NotMapped]
        public string ChapterName { get; set; }

        /// <summary>
        /// 字数
        /// </summary>
        [NotMapped]
        public int Count { get; set; }
        /// <summary>
        /// 作者笔名
        /// </summary>
        [NotMapped]
        public string Pseudonym { get; set; }
    }
}
