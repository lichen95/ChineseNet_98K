using System.Collections.Generic;

namespace ChineseNet_98K.IDAL
{
    using Entity;

    /// <summary>
    /// ** 描述：书评回复DAL接口层
    /// ** 创始时间：2018-11-26
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IBookReview_Answers_DAL : IBase_DAL<BookReview_Answers>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<BookReview_Answers> Query();
    }
}
