using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.Common;
    using ChineseNet_98K.Entity;
    using ChineseNet_98K.Reception.Content;
    using ChineseNet_98K.Reception.Models;
    using ChineseNet_98K.Reception.Service;
    using IBLL;
    using Nest;
    using Newtonsoft.Json;
    using Rotativa.AspNetCore;
    using System.Linq;

    public class NovelController : Controller
    {
        private INovels_BLL iNovels_BLL;
        private IChapters_BLL iChapters_BLL;
        private readonly ElasticClient _client;
        private IRanking_BLL ranking_BLL;

        public NovelController(INovels_BLL _iNovels_BLL, IEsClientProvider clientProvider, IChapters_BLL _iChapters_BLL, IRanking_BLL _ranking_BLL)
        {
            iNovels_BLL = _iNovels_BLL;
            _client = clientProvider.GetClient();
            iChapters_BLL = _iChapters_BLL;
            ranking_BLL = _ranking_BLL;
        }

        /// <summary>
        /// 全文检索
        /// </summary>
        /// <param name="wordkey">关键字</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns></returns>
        [HttpPost]
        public string GetNovelsByElasticSearch(string keyword, int pageIndex = 0, int pageSize = 20)
        {
            pageIndex = pageIndex - 1;
            var json = Client.GetApi("get", "estest?Key=" + keyword + "&from=" + pageIndex + "&size=" + pageSize, null);
            var novelList = JsonConvert.DeserializeObject<ESHelper.personList>(json);
            var result = JsonConvert.SerializeObject(novelList);
            return result;
        }

        /// <summary>
        /// 前台小说详情的显示
        /// </summary>
        /// <param name="typeIdOne">分类一</param>
        /// <param name="typeIdTwo">分类二</param>
        /// <param name="state">写作进度 连载中 已完结</param>
        /// <param name="sizeWord">字数</param>
        /// <param name="order">排序 1 字数 2更新时间</param>
        /// <returns></returns>
        [HttpPost]
        public string ShowNovel(int typeIdOne = -1, int typeIdTwo = -1, int state = -1, int minSize = -1, int maxSize = -1, int order = 0, int pageIndex = 1, int pageSize = 20)
        {
            var list = iNovels_BLL.Querys();
            if (typeIdOne != -1)
                list = list.Where(m => m.TypeIdOne.Equals(typeIdOne)).ToList();
            if (typeIdTwo != -1)
                list = list.Where(m => m.TypeIdTwo.Equals(typeIdTwo)).ToList();
            if (state != -1)
                list = list.Where(m => m.State.Equals(state)).ToList();
            if (minSize != -1 && maxSize != -1)
            {
                list = list.Where(m => m.WordSize >= minSize * 10000 && m.WordSize <= maxSize * 10000).ToList();
            }
            if (order == 1)
            {
                list = list.OrderByDescending(m => m.WordSize).ToList();
            }
            if (order == 2)
            {
                list = list.OrderByDescending(m => m.NewTime).ToList();
            }
            PageBox page = new PageBox
            {
                PageIndex = pageIndex,
                PageCount = list.Count,
                Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize)
            };
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iNovels_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(Novels n)
        {
            var result = iNovels_BLL.Update(n);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public int Delete(string Id)
        {
            var result = iNovels_BLL.Delete(Id);
            return result;
        }

        /// <summary>
        /// 查询章节信息
        /// </summary>
        /// <param name="Id">小说ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns></returns>
        [HttpPost]
        public string ShowChapter(int Id, int CId)
        {
            var result = iChapters_BLL.Show(Id).Where(m => m.ChapterId.Equals(CId)).ToList();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 小说章节信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string All(int Id, int RId)
        {
            var result = iChapters_BLL.All(Id).Where(m => m.rowId.Equals(RId)).FirstOrDefault();
            if (result.IsVIP == 1)
            {
                result.ChapterContent = result.ChapterContent.Substring(0, 200);
            }
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取章节信息
        /// </summary>
        /// <param name="Id">小说ID</param>
        /// <param name="order">排序</param>
        /// <param name="vid">分卷ID</param>
        /// <returns></returns>
        [HttpPost]
        public string QueryChapters(int Id, int order, int vid = -1)
        {
            if (order == 0)
            {
                var result = iChapters_BLL.All(Id).OrderBy(n => n.CreateDate).ToList();
                if (vid != -1)
                {
                    result = result.Where(m => m.VolumeId.Equals(vid)).ToList();
                }
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = iChapters_BLL.All(Id).OrderByDescending(n => n.CreateDate).ToList();
                return JsonConvert.SerializeObject(result);
            }
        }

        /// <summary>
        /// 根据小说ID获取章节数据
        /// </summary>
        /// <param name="NovelId">小说ID</param>
        /// <returns></returns>
        [HttpPost]
        public string GetChaptersByNovelId(int NovelId)
        {
            var result = iChapters_BLL.Show(NovelId);
            return JsonConvert.SerializeObject(result);
        }

        #region  排行榜
        /// <summary>
        /// 收藏排行榜
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        [HttpPost]
        public string CollectionRanking(int Num)
        {
            var result = ranking_BLL.CollectionRanking(Num);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 书评排行榜
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        [HttpPost]
        public string ReviewsRanking(int Num)
        {
            var result = ranking_BLL.ReviewsRanking(Num);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 月点击排行榜
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string MonthRanking()
        {
            var result = ranking_BLL.MonthRanking();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 周点击排行榜
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string WeekRanking()
        {
            var result = ranking_BLL.WeekRanking();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 新书周点击排行榜
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string NewbookRanking()
        {
            var result = ranking_BLL.NewbookRanking();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 数字排行榜
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string NumRanking()
        {
            var result = ranking_BLL.NumRanking();
            return JsonConvert.SerializeObject(result);
        }
        #endregion


        /// <summary>
        /// pdftest
        /// </summary>
        /// <returns></returns>
        public IActionResult DemoViewAsPDF()
        {
            return new ViewAsPdf("DemoViewAsPDF");
        }

        /// <summary>
        /// 生成pdf小说内容
        /// </summary>
        /// <returns></returns>
        public IActionResult DemoPageMarginsPDF(int NId)
        {
            var chapters = iChapters_BLL.All(NId);
            var report = new ViewAsPdf("DemoPageMarginsPDF", chapters)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
            };
            return report;
        }
    }
}