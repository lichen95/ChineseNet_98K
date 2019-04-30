using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.Common;
    using ChineseNet_98K.IBLL;
    using ChineseNet_98K.Reception.Content;
    using ChineseNet_98K.Reception.Models;
    using Entity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.IO;
    using System.Net.Http.Headers;
    using System.Web;

    /// <summary>
    /// ** 描述：作者
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class AuthorLRController : Controller
    {
        public IAuthorLR_BLL _IAuthorLR_BLL { get; }
        public INovels_BLL _Novels_BLL { get; }
        public ITypes_BLL _Types_BLL { get; }
        public IVolumes_BLL _Volumes_BLL { get; }
        public IChapters_BLL _Chapters_BLL { get; }
        public IProfits_BLL iProfits_BLL { get; }
        public IApprovals_BLL _iApprovals_BLL { get; }
        public IUsers_BLL iUsers_BLL { get; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public AuthorLRController(IAuthorLR_BLL _IAuthorLR_bll, INovels_BLL _Novels_bll, ITypes_BLL _Types_bll, IHostingEnvironment hostingEnvironment, IVolumes_BLL volumes_BLL, IChapters_BLL Chapters_BLL, IApprovals_BLL iApprovals_BLL, IUsers_BLL _iUsers_BLL, IProfits_BLL _iProfits_BLL)
        {
            _IAuthorLR_BLL = _IAuthorLR_bll;
            _Novels_BLL = _Novels_bll;
            _Types_BLL = _Types_bll;
            _hostingEnvironment = hostingEnvironment;
            _Volumes_BLL = volumes_BLL;
            _Chapters_BLL = Chapters_BLL;
            _iApprovals_BLL = iApprovals_BLL;
            iUsers_BLL = _iUsers_BLL;
            iProfits_BLL = _iProfits_BLL;
        }

        /// <summary>
        /// 注册作者
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AuthorAdd(Authors a)
        {
            a.IsContract = 0;
            a.State = 0;
            a.CreateDate = DateTime.Now;
            var result = 0;
            result = _IAuthorLR_BLL.Add(a);
            if (result > 0)
            {
                a.AuthorId = result;
                CookieHelper.SetCookies("AId", HttpUtility.UrlEncode(JsonConvert.SerializeObject(a)), 720);
                result = iUsers_BLL.UpState(a.UserId);
                var model = HttpUtility.UrlDecode(CookieHelper.GetCookies("UID"));
                Users user = JsonConvert.DeserializeObject<Users>(model);
                user.State = 1;
                CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(user)), 5040);
            }
            return result;
        }

        /// <summary>
        /// 作者登录
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Pwd"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public int Login(int type, string Pwd, int UserId)
        {
            if (type == 0)
            {
                var result = _IAuthorLR_BLL.AuthorLogin(Pwd, UserId);
                if (result != null)
                {
                    CookieHelper.SetCookies("AId", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)), 720);
                    return result.AuthorId;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        /// <summary>
        /// 退出作者登录
        /// </summary>
        /// <returns></returns>
        public void UnLogin()
        {
            var result = CookieHelper.GetCookies("AId");
            result = null;
            CookieHelper.SetCookies("AId", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result)), -1);
            var result1 = CookieHelper.GetCookies("UID");
            result1 = null;
            CookieHelper.SetCookies("UID", HttpUtility.UrlEncode(JsonConvert.SerializeObject(result1)), -1);
            Response.Redirect("/Home/Index");
        }


        /// <summary>
        /// 获取作者信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public List<Authors> Query()
        {
            var result = _IAuthorLR_BLL.Query();
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(Authors u)
        {
            var result = _IAuthorLR_BLL.Update(u);
            return result;
        }

        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetAuthorByid(int Id)
        {
            var result = _IAuthorLR_BLL.QueryById(Id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 作者密码修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AuthorUptpwd(Authors t)
        {
            var result = _IAuthorLR_BLL.Uptpwd(t);
            return result;
        }

        #region  作者添加作品
        /// <summary>
        /// 根据ID获取分类的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetTypeByid(int Id)
        {
            var result = _Types_BLL.Query().Where(m => m.PId == Id).ToList();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 创建作品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int CreatWork(Novels n)
        {
            if (n.AuthorMessage == null)
            {
                return -1;
            }
            if (n.ImgPath == null)
            {
                return -1;
            }
            if (n.LabelName == null)
            {
                return -1;
            }
            if (n.NovelDesc == null)
            {
                return -1;
            }
            if (n.NovelName == null)
            {
                return -1;
            }
            if (n.TypeIdOne == 0)
            {
                return -1;
            }
            if (n.TypeIdTwo == 0)
            {
                return -1;
            }
            WordFiter wordFiter = new WordFiter();
            n.NovelDesc = wordFiter.GetValues(n.NovelDesc);
            n.AuthorMessage = wordFiter.GetValues(n.AuthorMessage);
            n.NovelNum = DateTime.Now.Ticks.ToString() + n.AuthorId;
            n.CreateDate = DateTime.Now;
            var result = _Novels_BLL.Add(n);
            if (result > 0)
            {
                //添加作者收益信息
                Profits t = new Profits();
                t.CreateDate = DateTime.Now;
                t.NovelId = n.NovelId;
                t.TotalProfits = 0;
                t.UserId = n.AuthorId;
                t.AlreadySettled = 0;
                var aa = iProfits_BLL.Add(t);
            }
            return result;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string UploadFiles(string z)
        {
            long size = 0;
            var path = "";
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                string fileExt = Path.GetExtension(file.FileName); //文件扩展名
                long fileSize = file.Length; //获得文件大小，以字节为单位
                string newFileName = System.Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                path = "/upload/" + newFileName;
                path = _hostingEnvironment.WebRootPath + $@"\{path}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(path))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                path = "/upload/" + newFileName;
            }
            return path;
        }
        #endregion

        #region 章节与分卷
        /// <summary>
        /// 根据PID获取分卷信息
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetVolumes(int PId)
        {
            var result = _Volumes_BLL.Query().Where(m => m.PId.Equals(PId)).ToList();
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取分卷id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetVid(int id)
        {
            var result = _Volumes_BLL.QueryById(id);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 修改分卷名称
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPost]
        public string VolumesUpdate(Volumes v)
        {
            var result = _Volumes_BLL.Update(v);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 创建章节
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int CreateChapters(Chapters t)
        {
            if (t.ChapterName == null)
            {
                return -1;
            }
            if (t.ChapterContent == null)
            {
                return -1;
            }
            if (t.AuthorDesc == null)
            {
                t.AuthorDesc = " ";
            }
            //敏感词过滤
            WordFiter wordFiter = new WordFiter();
            t.ChapterContent = wordFiter.GetValues(t.ChapterContent);
            t.AuthorDesc = wordFiter.GetValues(t.AuthorDesc);
            t.CreateDate = DateTime.Now;
            t.WordSize = t.ChapterContent.Length;
            var result = _Chapters_BLL.Add(t);
            return result;
        }
        #endregion

        /// <summary>
        /// 提交审批
        /// </summary>
        /// <param name="NovelId">小说ID</param>
        /// <returns></returns>
        [HttpPost]
        public int AddApprovals(int NovelId)
        {
            List<Approvals> list = new List<Approvals>();
            var novel = _Novels_BLL.QueryById(NovelId);
            if (novel.State == 0)
            {
                Approvals t = new Approvals
                {
                    State = 0,
                    ApprovalMessage = "",
                    ChapterId = 0,
                    CreateDate = DateTime.Now,
                    NovelId = NovelId,
                    TypeId = 1
                };
                list.Add(t);
            }
            var listChapters = _Chapters_BLL.Query(NovelId);
            for (int i = 0; i < listChapters.Count; i++)
            {
                if (listChapters[i].State == 1)
                {
                    Approvals t = new Approvals
                    {
                        State = 0,
                        ApprovalMessage = "",
                        ChapterId = listChapters[i].ChapterId,
                        CreateDate = DateTime.Now,
                        NovelId = NovelId,
                        TypeId = 2
                    };
                    list.Add(t);
                }
            }
            var result = _iApprovals_BLL.Add(list);
            return result;
        }

        /// <summary>
        /// 显示草稿箱
        /// </summary>
        /// <param name="NId"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryChapters(int NId)
        {
            var result = _Chapters_BLL.Query(NId).Where(m => m.State == 0);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 删除草稿箱
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public int DelChapters(string id, int ids)
        {
            var result = _Chapters_BLL.DelChapters(id, ids);
            return result;
        }

        /// <summary>
        /// 根据id反填草稿箱信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public string FtChapters(int nid, int cid)
        {
            //var result = _Chapters_BLL.FtChapters(nid, cid);

            var result = _Chapters_BLL.Query(nid).Where(m => m.ChapterId.Equals(cid)).FirstOrDefault();

            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 草稿修改
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateChapters(Chapters c)
        {
            c.WordSize = c.ChapterContent.Length;
            var result = _Chapters_BLL.Update(c);
            return result;
        }

        /// <summary>
        /// 获取小说信息
        /// </summary>
        /// <param name="AuthorId">作者ID</param>
        /// <param name="state"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public string QueryNovels(int AuthorId, int state = -1, int pageIndex = 1, int pageSize = 5)
        {
            var list = _Novels_BLL.Query().Where(m => m.AuthorId.Equals(AuthorId)).ToList();
            if (state != -1)
                list = list.Where(m => m.State.Equals(state)).ToList();
            PageBox page = new PageBox();
            page.PageIndex = pageIndex;
            page.PageCount = list.Count / pageSize + (list.Count % pageSize > 0 ? 1 : 0);
            page.Data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return JsonConvert.SerializeObject(page);
        }
    }
}