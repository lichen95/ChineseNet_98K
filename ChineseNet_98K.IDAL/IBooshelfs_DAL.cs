using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseNet_98K.IDAL
{
    using Entity;
    /// <summary>
    /// ** 描述：我的书架
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public interface IBooshelfs_DAL:IBase_DAL<Booshelfs>
    {
        /// <summary>
        /// 书架的显示
        /// </summary>
        /// <returns></returns>
        List<Booshelfs> Query();
        /// <summary>
        /// 书签的添加
        /// </summary>
        /// <returns></returns>
        int AddBookmarks(Bookmarks book);
        /// <summary>
        /// 书签的修改
        /// </summary>
        /// <returns></returns>
        int UpdateBookmarks(int BId, int UserId, int NovelId,int ChapterId);
        /// <summary>
        /// 根据Id查询到书签的信息
        /// </summary>
        /// <returns></returns>
        Bookmarks QueryByIdBookmarks(int UserId, int NovelId);
    }
}
