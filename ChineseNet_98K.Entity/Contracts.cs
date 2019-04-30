using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ** 描述：申请签约表
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Contracts
    {
        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        [Key]
        public int ContractId { get; set; }

        /// <summary>
        /// Desc:作者ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        public int AuthorId { get; set; }

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
        /// Desc:作者笔名
        /// Default:
        /// Nullable:False
        /// </summary>   
        [NotMapped]
        public string Name { get; set; }
    }
}
