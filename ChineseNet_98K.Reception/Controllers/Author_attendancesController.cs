using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ChineseNet_98K.Reception.Controllers
{
    using ChineseNet_98K.Entity;
    using ChineseNet_98K.IBLL;
    using Newtonsoft.Json;

    /// <summary>
    /// ** 描述：稿费计算控制器
    /// ** 创始时间：2018-12-3
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Author_attendancesController : Controller
    {
        public IAuthor_attendances_BLL iAuthor_attendances_BLL;
        public IIncomeDetails_BLL iIncomeDetails_BLL;
        public IProfits_BLL iProfits_BLL;
        public IConsumptions_BLL iConsumptions_BLL;
        public IWallets_BLL iwallets_bll;
        public ISubscribes_BLL iSubscribes_BLL;
        public Author_attendancesController(IAuthor_attendances_BLL _iAuthor_attendances_BLL, IIncomeDetails_BLL _iIncomeDetails_BLL, IProfits_BLL _iProfits_BLL, IConsumptions_BLL _iConsumptions_BLL, IWallets_BLL _iwallets_bll, ISubscribes_BLL _iSubscribes_BLL)
        {
            iAuthor_attendances_BLL = _iAuthor_attendances_BLL;
            iIncomeDetails_BLL = _iIncomeDetails_BLL;
            iProfits_BLL = _iProfits_BLL;
            iConsumptions_BLL = _iConsumptions_BLL;
            iwallets_bll = _iwallets_bll;
            iSubscribes_BLL = _iSubscribes_BLL;
        }

        /// <summary>
        /// 月票K币订阅分红
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="authorId">作者ID</param>
        /// <param name="num">K币</param>
        /// <param name="novelId">小说ID</param>
        /// <param name="typeId">消费类型  1打赏2vip章节3全勤奖4排行榜奖励</param>
        /// <returns></returns>
        public int AddIncomeDetails(int userId,int authorId,int num,int novelId,int typeId)
        {
            //新增用户消费记录
            Consumptions c = new Consumptions
            {
                CreateDate = DateTime.Now,
                NovelId = novelId,
                Num = num,
                RechargeType = typeId,
                UserId = userId
            };
            var result= iConsumptions_BLL.Add(c);

            //新增作者稿酬信息
            if (typeId == 1)
            {
                IncomeDetails t = new IncomeDetails
                {
                    NovelId = novelId,
                    AuthorId = authorId,
                    CreateDate = DateTime.Now,
                    ProfitNum = Convert.ToDecimal(num * 0.6),
                    Types = typeId
                };
                result += iIncomeDetails_BLL.Add(t);
            }
            else if (typeId == 2)
            {
                IncomeDetails t = new IncomeDetails
                {
                    NovelId = novelId,
                    AuthorId = authorId,
                    CreateDate = DateTime.Now,
                    ProfitNum = Convert.ToDecimal(num * 0.4),
                    Types = typeId
                };
                result += iIncomeDetails_BLL.Add(t);
            }
            return result;
        }

        /// <summary>
        /// 收益详情
        /// </summary>
        /// <param name="authorId">作者ID</param>
        /// <param name="novelId">小说ID</param>
        /// <returns></returns>
        public string GetIncomeDetails(int authorId,int novelId)
        {
            var list = iIncomeDetails_BLL.Query();
            list = list.Where(m => m.AuthorId.Equals(authorId)&&m.NovelId.Equals(novelId)).ToList();
            return JsonConvert.SerializeObject(list);
        }
        
        /// <summary>
        /// 获取收益信息
        /// </summary>
        /// <param name="authorId">作者ID</param>
        /// <param name="novelId">小说ID</param>
        /// <returns></returns>
        public string GetProfits(int authorId, int novelId)
        {
            var list = iProfits_BLL.Query();
            list = list.Where(m => m.UserId.Equals(authorId)).ToList();
            //if(novelId!=0)
            // && m.NovelId.Equals(novelId)
            
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 根据用户id查询余额
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetUser(int Userid)
        {
            var result = iwallets_bll.GetUserid(Userid);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 打赏信息修改
        /// </summary>
        ///  <param name="userId">用户ID</param>
        /// <param name="authorId">作者ID</param>
        /// <param name="num">K币</param>
        /// <param name="novelId">小说ID</param>
        /// <param name="typeId">消费类型  1打赏2vip章节3全勤奖4排行榜奖励</param>
        /// <returns></returns>
        [HttpPost]
        public int UptWallets(int userId,int  authorId,int num,int  novelId,int  typeId)
        {
            var w = iwallets_bll.GetUserid(userId);
            w.Balance = w.Balance-num;
            var result = iwallets_bll.Update(w);
            AddIncomeDetails(userId, authorId, num, novelId, typeId);
            return result;
        }

        /// <summary>
        /// 订阅VIP章节
        /// </summary>
        ///  <param name="userId">用户ID</param>
        /// <param name="authorId">作者ID</param>
        /// <param name="num">K币</param>
        /// <param name="novelId">小说ID</param>
        /// <param name="typeId">消费类型  1打赏2vip章节3全勤奖4排行榜奖励</param>
        /// <param name="cids">订阅的章节集合</param>
        /// <returns></returns>
        [HttpPost]
        public int SubscribesAdd(int userId, int authorId, int num, int novelId, int typeId,string cids)
        {
            var w = iwallets_bll.GetUserid(userId);
            w.Balance = w.Balance - num;
            var result = iwallets_bll.Update(w);
            var cIds = cids.Split(',');
            for (int i = 0; i < cIds.Length; i++)
            {
                Subscribes t = new Subscribes
                {
                    ChapterId = Convert.ToInt32(cIds[i]),
                    CreateDate = DateTime.Now,
                    NovelId = novelId,
                    UserId = userId
                };
                result +=iSubscribes_BLL.Add(t);
            }
            result+=AddIncomeDetails(userId, authorId, num, novelId, typeId);
            return result;

        }
    }
}