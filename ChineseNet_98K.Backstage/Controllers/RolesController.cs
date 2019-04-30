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
    /// ** 描述：角色控制器
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class RolesController : Controller
    {
        public IRoles_BLL iRoles_BLL { get; }
        public RolesController(IRoles_BLL _iRoles_BLL)
        {
            iRoles_BLL = _iRoles_BLL;
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
        /// 新增
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(string PermissionIds, string PermissionNames, string RoleName)
        {
            Roles t = new Roles();
            t.RoleName = RoleName;
            t.PermissionIds = PermissionIds;
            t.PermissionNames = PermissionNames;
            t.IsUse = 1;
            t.CreateDate = DateTime.Now;
            var result = iRoles_BLL.Add(t);
            return result > 0;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iRoles_BLL.Delete(Ids);
            return result > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(int Id, string PermissionIds, string PermissionNames, string RoleName, DateTime CreateDate)
        {
            Roles t = new Roles();
            t.RoleId = Id;
            t.RoleName = RoleName;
            t.PermissionIds = PermissionIds;
            t.PermissionNames = PermissionNames;
            t.IsUse = 1;
            t.CreateDate = CreateDate;
            var result = iRoles_BLL.Update(t);
            return result > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(string roleName,int pageIndex,int pageSize)
        {
            var list = iRoles_BLL.Query();
            if (!string.IsNullOrWhiteSpace(roleName))
                list = list.Where(m => m.RoleName.Contains(roleName)).ToList();

            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count;
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var list = iRoles_BLL.QueryById(Id); 
            return JsonConvert.SerializeObject(list);
        }
    }
}