using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChineseNet_98K.Reception.Controllers
{
    using Common;
    using IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：消息管理
    /// ** 创始时间：2018-11-27
    /// ** 修改时间：
    /// ** 作者：lc
    /// </summary>
    public class MessagesController : Controller
    {
        public IMessages_BLL iMessages_BLL { get; }
        public MessagesController(IMessages_BLL _iMessages_BLL)
        {
            iMessages_BLL = _iMessages_BLL;
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string Query(int pageIndex = 1, int pageSize = 5)
        {
            var list = iMessages_BLL.Query();
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count / pageSize + (list.Count % pageSize > 0 ? 1 : 0);
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public int Delete(string Id)
        {
            var result = iMessages_BLL.Delete(Id);
            return result;
        }
    }
}