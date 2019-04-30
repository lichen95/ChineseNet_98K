using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ** 描述：审批类
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Approvals
    {
        public Approvals()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>  
        [Key]
        public int ApprovalId { get; set; }

        /// <summary>
        /// Desc:审批类型
        /// Default:1小说审批 2文章审批 
        /// Nullable:False
        /// </summary>  
        public int TypeId { get; set; }

        /// <summary>
        /// Desc:小说Id
        /// Default:
        /// Nullable:False
        /// </summary>  
        public int NovelId { get; set; }

        /// <summary>
        /// Desc:章节Id
        /// Default:
        /// Nullable:False
        /// </summary>  
        public int ChapterId { get; set; }

        /// <summary>
        /// Desc:审批意见
        /// Default:
        /// Nullable:False
        /// </summary>  
        public string ApprovalMessage { get; set; }

        /// <summary>
        /// Desc:审批状态
        /// Default:0未审核 1已通过 2未通过
        /// Nullable:False
        /// </summary>  
        public int State { get; set; }

        /// <summary>
        /// Desc:审批时间
        /// Default:
        /// Nullable:False
        /// </summary>  
        public DateTime CreateDate { get; set; }
    }
}
