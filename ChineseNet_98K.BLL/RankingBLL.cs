using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IDAL;
    using IBLL;
    public class RankingBLL : IRanking_BLL
    {
        private IRanking_DAL ranking_DAL;
        public RankingBLL(IRanking_DAL _ranking_DAL)
        {
            ranking_DAL = _ranking_DAL;
        }

        public List<Ranking> CollectionRanking(int Num)
        {
            try
            {
                var result = ranking_DAL.CollectionRanking(Num);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        /// <summary>
        /// 书评排行榜
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public List<Ranking> ReviewsRanking(int Num)
        {
            try
            {
                var result = ranking_DAL.ReviewsRanking(Num);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 月点击排行榜
        /// </summary>
        /// <returns></returns>
        public List<Ranking> MonthRanking()
        {
            try
            {
                var result = ranking_DAL.MonthRanking();
                return result;
            }
            catch (Exception)
            { 

                throw;
            }
        }
        /// <summary>
        /// 周点击排行榜
        /// </summary>
        /// <returns></returns>
        public List<Ranking> WeekRanking()
        {
            try
            {
                var result = ranking_DAL.WeekRanking();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 新书周点击排行榜
        /// </summary>
        /// <returns></returns>
        public List<Ranking> NewbookRanking()
        {
            try
            {
                var result = ranking_DAL.NewbookRanking();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 数字排行榜
        /// </summary>
        /// <returns></returns>
        public List<Novels> NumRanking()
        {
            try
            {
                var result = ranking_DAL.NumRanking();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
