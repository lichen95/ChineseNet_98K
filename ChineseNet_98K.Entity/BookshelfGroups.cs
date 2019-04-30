using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：书架分组表
    /// ** 创始时间：2018-11-21
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class BookshelfGroups
    {
        public BookshelfGroups()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>      
        [Key]
        public int BookshelfGroupId { get; set; }

        /// <summary>
        /// Desc:分组名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string BookshelfGroupName { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
