using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：书评BLL层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IBookReviews_BLL : IBase_BLL<BookReviews>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<BookReviews> Query();
    }
}
