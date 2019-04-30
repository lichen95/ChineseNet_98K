using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：小说类型类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Types
    {
        public Types()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary> 
        [Key]
        public int TypeId { get; set; }

        /// <summary>
        /// Desc:类型名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string TypeName { get; set; }

        /// <summary>
        /// Desc:父级ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int PId { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
