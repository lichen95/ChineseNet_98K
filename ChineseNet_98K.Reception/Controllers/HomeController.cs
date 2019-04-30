using Microsoft.AspNetCore.Mvc;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.Entity;
    using ChineseNet_98K.Reception.Content;
    using Newtonsoft.Json;
    using System.Web;

    public class HomeController : Controller
    {
        /// <summary>
        /// 用户状态
        /// </summary>
        private int State { get; set; }
        /// <summary>
        ///用户名
        /// </summary>
        private string UserName { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        private int UserId { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        private string Pwd { get; set; }

        /// <summary>
        /// 作者id
        /// </summary>
        private int AuthorId { get; set; }
        /// <summary>
        /// 笔名
        /// </summary>
        private string Pseudonym { get; set; }
        /// <summary>
        /// 是否签约
        /// </summary>
        private int IsContract { get; set; }
        /// <summary>
        /// 作者状态
        /// </summary>
        private int States { get; set; }
        /// <summary>
        /// 作者密码
        /// </summary>
        private string Pwds { get; set; }

        public HomeController()
        {
            this.UserId = 0;
        }

        /// <summary>
        /// 读取登录状态
        /// </summary>
        /// <returns></returns>
        public Users GetUser()
        {
            var result = HttpUtility.UrlDecode(CookieHelper.GetCookies("UID"));
            Users user = JsonConvert.DeserializeObject<Users>(result);
            if (user != null)
            {
                State = user.State;
                UserName = user.UserName;
                UserId = user.UserId;
                Pwd = user.Password;
            }
            return user;
        }

        /// <summary>
        /// 获取作者信息
        /// </summary>
        /// <returns></returns>
        public Authors GetAuthor()
        {
            var result = HttpUtility.UrlDecode(CookieHelper.GetCookies("AID"));
            Authors author = JsonConvert.DeserializeObject<Authors>(result);
            if (author != null)
            {
                AuthorId = author.AuthorId;
                IsContract = author.IsContract;
                Pseudonym = author.Pseudonym;
                States = author.State;
                Pwds = author.Password;
            }
            return author;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.User = GetUser();
            ViewBag.Author = GetAuthor();
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 书库页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Stack()
        {
            ViewBag.User = GetUser();
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 排行页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Ranking()
        {
            ViewBag.User = GetUser();
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 完本页面
        /// </summary>
        /// <returns></returns>
        public IActionResult End()
        {
            ViewBag.User = GetUser();
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 申请称为作者
        /// </summary>
        /// <returns></returns>
        public IActionResult ApplyWriter()
        {
            ViewBag.User = GetUser();
            ViewBag.UserName = UserName;
            return View();
        }

        /// <summary>
        /// 作者协议
        /// </summary>
        /// <returns></returns>
        public IActionResult WriterAgreement()
        {
            ViewBag.User = GetUser();
            ViewBag.UserName = UserName;
            return View();
        }

        /// <summary>
        /// 作者注册
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthorRegister()
        {
            ViewBag.User = GetUser();
            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 作者登陆页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AuthorLogin()
        {
            ViewBag.User = GetUser();
            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 作者首页(作品库)
        /// </summary>
        /// <returns></returns>
        public IActionResult AuthorIndex()
        {
            ViewBag.User = GetUser();
            ViewBag.UserName = UserName;
            ViewBag.Author = GetAuthor();
            ViewBag.Pseudonym = Pseudonym;
            ViewBag.AuthorId = AuthorId;
            ViewBag.State = States;
            return View();
        }

        /// <summary>
        /// 作者稿酬查询
        /// </summary>
        /// <returns></returns>
        public IActionResult AuthorProfits()
        {
            ViewBag.User = GetUser();
            ViewBag.UserName = UserName;
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 修改作者页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthorUpdate()
        {
            ViewBag.Author = GetAuthor();
            ViewBag.AuthorId = AuthorId;
            return View();
        }

        /// <summary>
        /// 修改作者密码
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthorUptPwd()
        {
            ViewBag.Author = GetAuthor();
            ViewBag.AuthorId = AuthorId;
            ViewBag.Pwd = Pwds;
            return View();
        }

        /// <summary>
        /// 草稿箱管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Drafts(int Id)
        {
            ViewBag.NId = Id;
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 创建作品
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateBooks()
        {
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 玄幻
        /// </summary>
        /// <returns></returns>
        public IActionResult Fantasy()
        {
            ViewBag.User = GetUser();
            return View();
        }

        /// <summary>
        /// 添加章节
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateChapters(string NovelName, int NId)
        {
            ViewBag.User = GetUser();
            ViewBag.NovelName = NovelName;
            ViewBag.NId = NId;
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 修改分卷信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateVolumes()
        {
            ViewBag.User = GetUser();
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 我的书架
        /// </summary>
        /// <returns></returns>
        public IActionResult Booshelfs()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 我的账户
        /// </summary>
        /// <returns></returns>
        public IActionResult Wallets()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 个人资料
        /// </summary>
        /// <returns></returns>
        public IActionResult PersonalData()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 用户上传头像
        /// </summary>
        /// <returns></returns>
        public IActionResult PersonalImg()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <returns></returns>
        public IActionResult PersonalPwd()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            ViewBag.Pwd = Pwd;
            return View();
        }

        /// <summary>
        /// 我的消息
        /// </summary>
        /// <returns></returns>
        public IActionResult MyMessages()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 历史阅读
        /// </summary>
        /// <returns></returns>
        public IActionResult HistoricalReadings()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 小说详情
        /// </summary>
        /// <returns></returns>
        public IActionResult Details(int Id)
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            ViewBag.Id = Id;
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 目录
        /// </summary>
        /// <returns></returns>
        public IActionResult Catalogue(int Id)
        {
            ViewBag.User = GetUser();
            ViewBag.id = Id;
            ViewBag.State = State;
            return View();
        }

        /// <summary>
        /// 章节
        /// </summary>
        /// <returns></returns>
        public IActionResult Chapter(int Id, int RId)
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            ViewBag.NID = Id;
            ViewBag.RId = RId;
            return View();
        }

        /// <summary>
        /// 编辑作品
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateBooks(int Id)
        {
            ViewBag.User = GetUser();
            ViewBag.Id = Id;
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 作者信箱
        /// </summary>
        /// <returns></returns>
        public IActionResult Messagelist()
        {
            ViewBag.User = GetUser();
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 作者草稿信息修改
        /// </summary>
        /// <returns></returns>
        public ActionResult ChatersUpt(int NId,int CId)
        {
            ViewBag.User = GetUser();
            ViewBag.NId = NId;
            ViewBag.CId = CId;
            ViewBag.Author = GetAuthor();
            return View();
        }

        /// <summary>
        /// 充值页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Pay()
        {
            ViewBag.User = GetUser();
            ViewBag.UserId = UserId;
            return View();
        }

        /// <summary>
        /// 搜索页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Search(string keyword)
        {
            ViewBag.User = GetUser();
            ViewBag.keyword = keyword;
            ViewBag.UserId = UserId;
            return View();
        }


        /// <summary>
        /// 订阅页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Subscribes(int NId,int AuthorId)
        {
            ViewBag.NId = NId;
            ViewBag.User = GetUser();
            ViewBag.AuthorId = AuthorId;
            return View();
        }

        /// <summary>
        /// 发布新帖(新评论)
        /// </summary>
        /// <returns></returns>
        public IActionResult PublicationReview()
        {
            return View();
        }

        /// <summary>
        /// 回复评论
        /// </summary>
        /// <returns></returns>
        public IActionResult ReplyComments()
        {
            return View();
        }
    }
}