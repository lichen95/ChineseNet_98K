using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Backstage.Controllers
{
    using ChineseNet_98K.Common;
    using Entity;
    using IBLL;
    using Newtonsoft.Json;
    /// <summary>
    /// ** 描述：申请签约控制器
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>

    public class ContractsController : Controller
    {
        public IContracts_BLL iContracts_BLL { get; }
        public IAuthorLR_BLL iAuthorLR_BLL { get; }
        public INovels_BLL iNovels_BLL { get; }
        public ContractsController(IContracts_BLL _iContracts_BLL, IAuthorLR_BLL _iAuthorLR_BLL, INovels_BLL _iNovels_BLL)
        {
            iContracts_BLL = _iContracts_BLL;
            iAuthorLR_BLL = _iAuthorLR_BLL;
            iNovels_BLL = _iNovels_BLL;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Item(int Id,int AId)
        {
            ViewBag.Id = Id;
            ViewBag.AId = AId;
            return View();
        }

        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int Add(Contracts t)
        {
            var result = iContracts_BLL.Add(t);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Query(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 5)
        {
            var list = iContracts_BLL.Query();
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
        /// 根据ID获取作者信息
        /// </summary>
        /// <param name="Id">作者ID</param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
           var author= iAuthorLR_BLL.QueryById(Id);
            var novels=iNovels_BLL.Query().Where(m => m.AuthorId.Equals(Id)).ToList();
            for (int i = 0; i < novels.Count; i++)
            {
                author.AuthorBooks += "《" + novels[i].NovelName + "》、";
            }
            author.AuthorBooks = author.AuthorBooks.Substring(0, author.AuthorBooks.Length-1);
            return JsonConvert.SerializeObject(author);
        }

        /// <summary>
        /// 审批(修改)
        /// </summary>
        /// <param name="Id">申请签约表ID</param>
        /// <param name="AuthorId">作者ID</param>
        /// <param name="state">状态 0未审核  1未通过 2已通过</param>
        /// <returns></returns>
        [HttpPost]
        public int Update(int Id,int AuthorId, int State)
        {
            var t = iContracts_BLL.QueryById(Id);
            t.State = State;
            var result = iContracts_BLL.Update(t);
            if (result > 0&& State == 2)
            {
                var author = iAuthorLR_BLL.QueryById(AuthorId);
                author.IsContract = 1;
                var resultAuthor = iAuthorLR_BLL.Update(author);
            }
            return result;
        }

    }
}