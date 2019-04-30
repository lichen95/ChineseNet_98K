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
    /// ** 描述：小说类型
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class TypesController : Controller
    {
        public ITypes_BLL iTypes_BLL { get; }
        public TypesController(ITypes_BLL _iTypes_BLL)
        {
            iTypes_BLL = _iTypes_BLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iTypes_BLL.Delete(Ids);
            return result > 0;
        }

        /// <summary>
        ///  新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(Types t)
        {
            t.CreateDate = DateTime.Now;
            var result = iTypes_BLL.Add(t);
            return result > 0;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(Types t)
        {
            var result = iTypes_BLL.Update(t);
            return result > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="TypeName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(string TypeName,int pageIndex,int pageSize)
        {
            var list = iTypes_BLL.Query();
            if (!string.IsNullOrWhiteSpace(TypeName))
                list = list.Where(m => m.TypeName.Contains(TypeName)).ToList();

            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var list = iTypes_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 根据PID获取二级
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetTypesByPId(int PId)
        {
            var list = iTypes_BLL.Query();
            if (list != null)
                list = list.Where(m => m.PId.Equals(PId)).ToList();
            return JsonConvert.SerializeObject(list);
        }

    }
}