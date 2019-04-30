using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChineseNet_98K.ResourceManagement.Content
{
    public class PictureOptions
    {
        /// <summary>
        /// 允许的文件类型
        /// </summary>
        public string FileTypes { get; set; }
        /// <summary>
        /// 最大文件大小
        /// </summary>
        public int MaxSize { get; set; }
        /// <summary>
        /// 缩略图宽度
        /// </summary>
        public int ThumsizeW { get; set; }
        /// <summary>
        /// 缩略图高度
        /// </summary>
        public int ThumsizeH { get; set; }
        /// <summary>
        /// 是否缩略图
        /// </summary>
        public bool MakeThumbnail { get; set; }
        /// <summary>
        /// 图片的基地址
        /// </summary>
        public string ImageBaseUrl { get; set; }
    }
}
