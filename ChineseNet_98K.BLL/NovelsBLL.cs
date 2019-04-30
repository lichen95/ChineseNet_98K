using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：小说信息BLL层
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class NovelsBLL : INovels_BLL
    {
        private INovels_DAL iNovels_DAL;
        private IChapters_DAL iChapters_DAL;

        public NovelsBLL(INovels_DAL _iNovels_DAL, IChapters_DAL _iChapters_DAL)
        {
            iNovels_DAL = _iNovels_DAL;
            iChapters_DAL = _iChapters_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Novels t)
        {
            var result = iNovels_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="Ids">权限ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var result = iNovels_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回</returns>
        public List<Novels> Query()
        {
            var result = iNovels_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回信息</returns>
        public Novels QueryById(int Id)
        {
            var list = Querys();
            return list.Where(n => n.NovelId.Equals(Id)).OrderByDescending(m => m.CreateDate).FirstOrDefault();
        }

        /// <summary>
        /// 前台小说显示
        /// </summary>
        /// <returns></returns>
        public List<Novels> Querys()
        {
            var result = iNovels_DAL.Query();
            List<Novels> li = new List<Novels>();
            foreach (var item in result)
            {
                var list = iChapters_DAL.Query(item.NovelId).OrderByDescending(m => m.CreateDate).ToList();
                var count = 0;
                foreach (var it in list)
                {
                    count = count + it.WordSize;
                }
                if (list.Count != 0)
                {
                    item.NewTime = list.FirstOrDefault().CreateDate;
                    item.ChapterName = list.FirstOrDefault().ChapterName;
                    item.Count = count;
                    li.Add(item);
                }
            }
            return li;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Novels t)
        {
            var result = iNovels_DAL.Update(t);
            return result;
        }
    }
}
