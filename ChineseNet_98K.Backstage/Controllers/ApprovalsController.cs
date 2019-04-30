using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using Entity;
    using IBLL;
    using Common;
    using Newtonsoft.Json;
    using System.Web;
    using ChineseNet_98K.Backstage.wwwroot;
    /// <summary>
    /// ** 描述：审批管理
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class ApprovalsController : Controller
    {
        public IApprovals_BLL iApprovals_BLL { get; }
        public INovels_BLL iNovels_BLL { get; }
        public IChapters_BLL iChapters_BLL { get; }
        public IMessages_BLL iMessages_BLL { get; }
        public ApprovalsController(IApprovals_BLL _iApprovals_BLL, INovels_BLL _iNovels_BLL, IChapters_BLL _iChapters_BLL, IMessages_BLL _iMessages_BLL)
        {
            iApprovals_BLL = _iApprovals_BLL;
            iNovels_BLL = _iNovels_BLL;
            iChapters_BLL = _iChapters_BLL;
            iMessages_BLL = _iMessages_BLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Item(int TypeId, int NovelId, int ChapterId,int ApprovalId)
        {
            ViewBag.TypeId = TypeId;
            ViewBag.NovelId = NovelId;
            ViewBag.ChapterId = ChapterId;
            ViewBag.ApprovalId = ApprovalId;
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate,int pageIndex,int pageSize)
        {
            var list = iApprovals_BLL.Query().OrderByDescending(m=>m.CreateDate).ToList();
            if (!string.IsNullOrWhiteSpace(startDate.ToString()))
                list = list.Where(m => m.CreateDate >= Convert.ToDateTime(startDate)).ToList();
            if (!string.IsNullOrWhiteSpace(endDate.ToString()))
                list = list.Where(m => m.CreateDate <= Convert.ToDateTime(endDate)).ToList();
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }


        /// <summary>
        /// 根据ID获取要审批的具体信息
        /// </summary>
        /// <param name="typeId">类型ID</param>
        /// <param name="novelId">小说ID</param>
        /// <param name="ChapterId">章节ID</param>
        /// <returns></returns>
        [HttpPost]
        public string GetData(int TypeId, int NovelId, int ChapterId)
        {
            if (TypeId == 1)
            {
                var list = iNovels_BLL.Query().Where(m=>m.NovelId.Equals(NovelId)).FirstOrDefault();
                return JsonConvert.SerializeObject(list);
            }
            if (TypeId == 2)
            {
                //存储过程  传入小说ID查询到具体表
                var list = iChapters_BLL.Query(NovelId).Where(m=>m.ChapterId.Equals(ChapterId)).FirstOrDefault();
                return JsonConvert.SerializeObject(list);
            }
            else
            {
                return "";                         
            }
        }

        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="Id">审批表ID</param>
        /// <param name="State">状态  2同意 1不同意</param>
        /// <param name="ApprovalMessage">审批意见</param>
        /// <param name="NovelId">小说ID</param>
        /// <param name="ChapterId">章节ID</param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(int Id,int State,string ApprovalMessage,int NovelId,int ChapterId)
        {
           var result=iApprovals_BLL.Update(Id, State,ApprovalMessage, NovelId, ChapterId);
            return result > 0;
        }
    }
}