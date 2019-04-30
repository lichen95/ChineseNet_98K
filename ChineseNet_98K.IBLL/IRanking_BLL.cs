using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IBLL
{
    using Entity;
    public interface IRanking_BLL
    {
        /// <summary>
        /// 收藏排行榜
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        List<Ranking> CollectionRanking(int Num);
        /// <summary>
        /// 书评排行榜
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        List<Ranking> ReviewsRanking(int Num);
        /// <summary>
        /// 月点击排行榜
        /// </summary>
        /// <returns></returns>
        List<Ranking> MonthRanking();
        /// <summary>
        /// 周点击排行榜
        /// </summary>
        /// <returns></returns>
        List<Ranking> WeekRanking();
        /// <summary>
        /// 新书周点击排行榜
        /// </summary>
        /// <returns></returns>
        List<Ranking> NewbookRanking();
        /// <summary>
        /// 数字排行榜
        /// </summary>
        /// <returns></returns>
        List<Novels> NumRanking();
    }
}
