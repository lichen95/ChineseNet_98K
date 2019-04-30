using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;

    ///<summary>
    ///消息类
    ///</summary>
    public partial class Messages
    {
        public Messages()
        {

        }

        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>   
        [Key]
        public int MessageId { get; set; }

        /// <summary>
        /// Desc:留言标题
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MessageTitle { get; set; }

        /// <summary>
        /// Desc:发送人
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MessageName { get; set; }

        /// <summary>
        /// Desc:接收人
        /// Default:
        /// Nullable:False
        /// </summary>   
        public int UserId { get; set; }

        /// <summary>
        /// Desc:留言内容
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MessageContent { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime CreateDate { get; set; }
    }
}
