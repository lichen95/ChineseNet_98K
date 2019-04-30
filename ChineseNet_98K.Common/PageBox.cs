namespace ChineseNet_98K.Common
{
    /// <summary>
    /// ** 描述：分页类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class PageBox
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
