using System.Collections.Generic;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：审批管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public interface IChapters_BLL : IBase_BLL<Chapters>
    {
        /// <summary>
        /// 获取章节信息
        /// </summary>
        /// <returns></returns>
        List<Chapters> Query(int novelId);

        /// <summary>
        /// 根据小说id显示草稿箱
        /// </summary>
        /// <param name="NovelId"></param>
        /// <param name="VolumeName"></param>
        /// <returns></returns>
        Chapters ChaChapters(int NovelId);

        /// <summary>
        /// 查询章节信息
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        List<Chapters> Show(int NovelId);

        /// <summary>
        /// 删除草稿
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        int DelChapters(string id, int ids);
        /// <summary>
        /// 根据草稿id反填
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        int FtChapters(string id, int ids);

        /// <summary>
        /// 获取小说章节信息
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        List<ChapterHelper> All(int NovelId);
    }
}
