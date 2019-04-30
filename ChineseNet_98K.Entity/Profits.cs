using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    /// 稿费表
    ///</summary>
    public partial class Profits
    {
        public Profits()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>     
        [Key]
        public int ProfitId { get; set; }


        /// <summary>
        /// Desc:书号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int NovelId { get; set; }

        /// <summary>
        /// Desc:总稿酬
        /// Default:
        /// Nullable:False
        /// </summary>           
        public decimal TotalProfits { get; set; }

        /// <summary>
        /// Desc:已结算稿酬
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int AlreadySettled { get; set; }

        /// <summary>
        /// Desc:作者ID
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
    }
}
