using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    ///等级表
    ///</summary>
    public partial class Vermicellis
    {
        public Vermicellis()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>     
        [Key]
        public int VermicelliId { get; set; }

        /// <summary>
        /// Desc:等级名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string VermicelliName { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
