using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ** 描述：书架表
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Booshelfs
    {
        public Booshelfs()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>    
        [Key]
        public int BookshelfId { get; set; }

        /// <summary>
        /// Desc:小说ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int NovelId { get; set; }

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

        /// <summary>
        /// Desc:分组ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int BookshelfGroupId { get; set; }
        /// <summary>
        /// Desc：分类名
        /// Default:
        /// Nullable:False
        /// </summary>
        [NotMapped]
        public string TypeName { get; set; }
        /// <summary>
        /// Desc:书名
        /// Default:
        /// Nullable:False
        /// </summary>   
        [NotMapped]
        public string NovelName { get; set; }
        /// <summary>
        /// Desc:真实姓名
        /// Default:
        /// Nullable:True
        /// </summary>    
        [NotMapped]
        public string Name { get; set; }
        /// <summary>
        /// Desc:章节名称
        /// Default:
        /// Nullable:False
        /// </summary>  
        [NotMapped]
        public string ChapterName { get; set; }
        /// <summary>
        /// Desc:更新时间
        /// Default:
        /// Nullable:False
        /// </summary>  
        [NotMapped]
        public DateTime Time { get; set; }
        /// <summary>
        /// Desc:封面路径
        /// Default:
        /// Nullable:False
        /// </summary>  
        [NotMapped]
        public string ImgPath { get; set; }
    }
}
