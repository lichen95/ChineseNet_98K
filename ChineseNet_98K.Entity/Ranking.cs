using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// ** 描述：书架表
    /// ** 创始时间：2018-12-3
    /// ** 修改时间：--
    /// ** 作者：whd
    /// </summary>
    public partial class Ranking
    {
        public Ranking()
        {

        }
        /// <summary>
        /// 小说名
        /// </summary>
        [NotMapped]
        public string NovelName { get; set; }
        /// <summary>
        /// 作者的笔名
        /// </summary>
        [NotMapped]
        public string Pseudonym { get; set; }
        /// <summary>
        /// 小说类型
        /// </summary>
        [NotMapped]
        public string TypeName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [NotMapped]
        public string ImgPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public int Counts { get; set; }

        /// <summary>
        /// 小说Id
        /// </summary>
        [NotMapped]
        public int NovelId { get; set; }
    }
}
