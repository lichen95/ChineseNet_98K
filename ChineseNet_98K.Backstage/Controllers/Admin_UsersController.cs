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
    /// ** 描述：用户控制器
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：2018-11-23
    /// ** 作者：lc
    /// </summary>
    public class Admin_UsersController : Controller
    {

        public IAdmin_Users_BLL iAdmin_Users_BLL { get; }
        public IRoles_BLL iRoles_BLL { get; }
        public Admin_UsersController(IAdmin_Users_BLL _iAdmin_Users_BLL, IRoles_BLL _iRoles_BLL)
        {
            iAdmin_Users_BLL = _iAdmin_Users_BLL;
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
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <param name="RoleIds"></param>
        /// <param name="RoleNames"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(string UserName, string UserPwd, string RoleIds, string RoleNames,int State)
        {
            Admin_Users admin = new Admin_Users();
            admin.Admin_UserName = UserName;
            admin.Admin_UserPwd = Md5Helper.MD5Encoding(UserPwd, 123);
            admin.CreateDate = DateTime.Now;
            admin.RoleIds = RoleIds;
            admin.RoleNames = RoleNames;
            admin.State = State;
            var result = iAdmin_Users_BLL.Add(admin);
            return result>0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(string Ids)
        {
            var result = iAdmin_Users_BLL.Delete(Ids);
            return result > 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Update(int Id, string UserName, string UserPwd, string RoleIds, string RoleNames, DateTime CreateDate,int State)
        {
            Admin_Users admin = new Admin_Users();
            admin.Admin_UserId = Id;
            admin.Admin_UserName = UserName;
            admin.Admin_UserPwd = UserPwd;
            admin.CreateDate = DateTime.Now;
            admin.RoleIds = RoleIds;
            admin.RoleNames = RoleNames;
            admin.State = State;
            var result = iAdmin_Users_BLL.Update(admin);
            return result > 0;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="UserName"></param>
        /// <param name="RoleName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(DateTime? startDate,DateTime? endDate,string UserName,string RoleName, int pageIndex,int pageSize)
        {
            var list = iAdmin_Users_BLL.Query();
            if (!string.IsNullOrWhiteSpace(UserName))
                list = list.Where(m => m.Admin_UserName.Contains(UserName)).ToList();
            if (!string.IsNullOrWhiteSpace(RoleName))
                list = list.Where(m => m.RoleNames.Contains(RoleName)).ToList();
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
        /// 根据ID获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryById(int Id)
        {
            var list = iAdmin_Users_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetRoles()
        {
            var result = iRoles_BLL.Query();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpPost]
        public int CheckUserName(string UserName)
        {
            var result = iAdmin_Users_BLL.Query();
            if (!string.IsNullOrWhiteSpace(UserName))
                result = result.Where(m => m.Admin_UserName.Equals(UserName)).ToList();
            return result.Count;
        }
    }
}