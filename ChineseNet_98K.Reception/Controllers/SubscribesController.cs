using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Reception.Controllers
{
    using IBLL;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// ** 描述：订阅章节DAL层
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class SubscribesController : Controller
    {
        public ISubscribes_BLL iSubscribes_BLL { get; }
        public IChapters_BLL iChapters_BLL { get; }
        public SubscribesController(ISubscribes_BLL _iSubscribes_BLL, IChapters_BLL _iChapters_BLL)
        {
            iSubscribes_BLL = _iSubscribes_BLL;
            iChapters_BLL = _iChapters_BLL;
        }
        
        /// <summary>
        /// 根据用户ID和小说ID获取章节信息
        /// </summary>
        /// <param name="NovelId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetChaptersByNovelId(int NovelId,int UserId)
        {
            var chapters = iChapters_BLL.Show(NovelId);
            var sub = iSubscribes_BLL.Query();
            for (int i = 0; i < chapters.Count; i++)
            {
                for (int j = 0; j < sub.Count; j++)
                {
                    var su = sub.Where(m => m.NovelId.Equals(chapters[i].NovelId) && m.ChapterId.Equals(chapters[i].ChapterId) && m.UserId.Equals(UserId)).FirstOrDefault();
                    if (su != null)
                    {
                        chapters[i].orderStatus = 1;
                    }
                }
            }
            return JsonConvert.SerializeObject(chapters);
        }
    }
}