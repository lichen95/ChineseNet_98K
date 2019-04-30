using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseNet_98K.Reception.Models
{
    public class ESHelper
    {
        /// <summary>
        /// ik分词结果对象
        /// </summary>
        public class ik
        {
            public List<tokens> tokens { get; set; }
        }
        public class tokens
        {
            public string token { get; set; }
            public int start_offset { get; set; }
            public int end_offset { get; set; }
            public string type { get; set; }
            public int position { get; set; }
        }

        /// <summary>
        /// 测试数据对象
        /// </summary>
        public class personList
        {
            public personList()
            {
                this.list = new List<ESHelper.novels>();
            }
            public int hits { get; set; }
            public int took { get; set; }
            public List<ESHelper.novels> list { get; set; }
        }
        public class person
        {
            public string id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public bool sex { get; set; }
            public DateTime birthday { get; set; }
            public string intro { get; set; }
        }
        public class novels
        {

            /// <summary>
            /// Desc:主键ID
            /// Default:
            /// Nullable:False
            /// </summary>    
            public int novelid { get; set; }

            /// <summary>
            /// Desc:书号
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string novelnum { get; set; }

            /// <summary>
            /// Desc:书名
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string novelname { get; set; }

            /// <summary>
            /// Desc:作者ID
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int authorid { get; set; }

            /// <summary>
            /// Desc:简介
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string noveldesc { get; set; }

            /// <summary>
            /// Desc:标签
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string labelname { get; set; }

            /// <summary>
            /// Desc:封面路径
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string imgpath { get; set; }

            /// <summary>
            /// Desc:作者寄语
            /// Default:
            /// Nullable:False
            /// </summary>           
            public string authormessage { get; set; }

            /// <summary>
            /// Desc:类型ID
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int typeidone { get; set; }

            /// <summary>
            /// Desc:类型ID
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int typeidtwo { get; set; }

            /// <summary>
            /// Desc:状态
            /// Default:
            /// Nullable:False
            /// </summary>           
            public int state { get; set; }

            /// <summary>
            /// Desc:创建时间
            /// Default:
            /// Nullable:False
            /// </summary>           
            public DateTime createdate { get; set; }

            /// <summary>
            /// Desc:总字数
            /// Default:
            /// Nullable:False
            /// </summary>        
            public int wordsize { get; set; }


            /// <summary>
            /// Desc:作者名称
            /// Default:
            /// Nullable:False
            /// </summary>   
            public string authorname { get; set; }

        }
    }
    
}