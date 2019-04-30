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
    /// ** 描述：权限控制器
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>

    public class PermissionsController : Controller
    {
        public IPermissions_BLL iPermissions_BLL { get; }
        public PermissionsController( IPermissions_BLL _iPermissions_BLL)
        {
            iPermissions_BLL = _iPermissions_BLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 获取父级权限
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetPermissions(int PId)
        {
            var result = iPermissions_BLL.Query();
            if (PId != -1)
                result = result.Where(m => m.PId.Equals(PId)).ToList();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(Permissions p)
        {
            p.CreateDate = DateTime.Now;
            p.IsUse = 1;
            var result = iPermissions_BLL.Add(p);
            return result>0;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(string permissionName,int pageIndex,int pageSize)
        {
            var list = iPermissions_BLL.Query();
            if (!string.IsNullOrWhiteSpace(permissionName))
                list = list.Where(m => m.PermissionName.Contains(permissionName)).ToList();

            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iPermissions_BLL.Delete(Ids);
            return result>0;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var result = iPermissions_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 权限更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(Permissions p)
        {
            var result = iPermissions_BLL.Update(p);
            return result > 0;
        }
    }
}