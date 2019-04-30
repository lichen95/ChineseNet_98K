using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：章节管理业务逻辑层
    /// ** 创始时间：2018-11-25
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ChaptersBLL : IChapters_BLL
    {
        private IChapters_DAL iChapters_DAL;
        public ChaptersBLL(IChapters_DAL _iChapters_DAL)
        {
            iChapters_DAL = _iChapters_DAL;
        }

        /// <summary>
        /// 新增章节
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Chapters t)
        {
            var result = iChapters_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 根据小说id显示草稿箱
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        public Chapters ChaChapters(int NovelId)
        {
            var result = iChapters_DAL.ChaChapters(NovelId);
            return result;
        }

        /// <summary>
        /// 删除草稿箱
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DelChapters(string id, int ids)
        {
            var result = iChapters_DAL.DelChapters(id, ids);
            return result;
        }
        /// <summary>
        /// 草稿箱反填
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int FtChapters(string id, int ids)
        {
            var result = iChapters_DAL.FtChapters(id, ids);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iChapters_DAL.Delete(Ids);
            return result;
        }
 

        /// <summary>
        /// 获取章节信息
        /// </summary>
        /// <returns></returns>
        public List<Chapters> Query(int novelId)
        {
            var result = iChapters_DAL.Query(novelId);
            return result;
        }

        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Chapters QueryById(int Id)
        {
            var result = iChapters_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 查询章节信息
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        public List<Chapters> Show(int NovelId)
        {
            var result = iChapters_DAL.Show(NovelId);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Chapters t)
        {
            var result = iChapters_DAL.Update(t);
            return result;
        }

        /// <summary>
        /// 获取小说章节信息
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        public List<ChapterHelper> All(int NovelId)
        {
            var result = iChapters_DAL.All(NovelId);
            return result;
        }
    }
}
