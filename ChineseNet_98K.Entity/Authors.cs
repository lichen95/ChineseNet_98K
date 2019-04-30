using System;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ** 描述：作者类
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public partial class Authors
    {
        public Authors()
        {

        }


        /// <summary>
        /// Desc:主键ID
        /// Default:
        /// Nullable:False
        /// </summary>         
        [Key]
        public int AuthorId { get; set; }

        /// <summary>
        /// Desc:真实姓名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:笔名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Pseudonym { get; set; }

        /// <summary>
        /// Desc:手机号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Phone { get; set; }

        /// <summary>
        /// Desc:密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Password { get; set; }

        /// <summary>
        /// Desc:邮箱
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Email { get; set; }

        /// <summary>
        /// Desc:QQ
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string QQ { get; set; }

        /// <summary>
        /// Desc:身份证
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string IdCard { get; set; }

        /// <summary>
        /// Desc:作者简介
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AuthorDesc { get; set; }

        /// <summary>
        /// Desc:地址
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Address { get; set; }

        /// <summary>
        /// Desc:邮编
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Postcode { get; set; }

        /// <summary>
        /// Desc:是否签约
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int IsContract { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Desc:身份证复印件
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string IdCardPath { get; set; }

        /// <summary>
        /// Desc:是否启用
        /// Default:
        /// Nullable:True
        /// </summary>  
        public int State { get; set; }
        
        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:True
        /// </summary>  
        public int UserId { get; set; }
        
        /// <summary>
        /// Desc:主要作品
        /// Default:
        /// Nullable:True
        /// </summary>  
        [NotMapped]
        public string AuthorBooks { get; set; }
        /// <summary>
        /// Desc:验证码
        /// Default:
        /// Nullable:True
        /// </summary>  
        [NotMapped]
        public string Yzm { get; set; }
    }
}
