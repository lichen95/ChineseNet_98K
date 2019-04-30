using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：小说分卷类
    /// ** 创始时间：2018-11-21
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Volumes
    {
        public Volumes()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>     
        [Key]
        public int VolumeId { get; set; }

        /// <summary>
        /// Desc:分卷名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string VolumeName { get; set; }

        /// <summary>
        /// Desc:父级ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int PId { get; set; }
        
        /// <summary>
        /// Desc:小说ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int NovelId { get; set; }
        
        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
