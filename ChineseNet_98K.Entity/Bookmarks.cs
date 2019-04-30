using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：书签表
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Bookmarks
    {
        public Bookmarks()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>         
        [Key]
        public int BookmarkId { get; set; }

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
    }
}
