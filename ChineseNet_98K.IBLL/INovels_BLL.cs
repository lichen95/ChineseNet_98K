using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：小说信息DAL接口
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface INovels_BLL : IBase_BLL<Novels>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>获取数据</returns>
        List<Novels> Query();

        /// <summary>
        /// 前台小说显示
        /// </summary>
        /// <returns></returns>
        List<Novels> Querys();
    }
}
