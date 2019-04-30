using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    ///礼物类
    ///</summary>
    public partial class Gifts
    {
        public Gifts()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>     
        [Key]
        public int GiftId { get; set; }

        /// <summary>
        /// Desc:礼物名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GiftName { get; set; }

        /// <summary>
        /// Desc:礼物类型
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GiftType { get; set; }

        /// <summary>
        /// Desc:价值/K币
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int Cost { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
