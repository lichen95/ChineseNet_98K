using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    ///消费类
    ///</summary>
    public partial class Consumptions
    {
        public Consumptions()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        [Key]
        public int ConsumptionId { get; set; }

        /// <summary>
        /// Desc:消费98K币数
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Num { get; set; }

        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc:充值类型ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int RechargeType { get; set; }

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
