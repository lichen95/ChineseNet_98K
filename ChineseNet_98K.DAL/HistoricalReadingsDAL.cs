using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ** 描述：最近阅读
    /// ** 创始时间：2018-11-22
    /// ** 修改时间：-
    /// ** 作者：whd
    /// </summary>
    public class HistoricalReadingsDAL : IHistoricalReadings_DAL
    {
        private readonly EFDbContext dbContext;
        public HistoricalReadingsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 最近阅读的添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(HistoricalReadings t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 删除历史阅读
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var t = QueryById(Convert.ToInt32(arr[i]));
                dbContext.Entry(t).State = EntityState.Deleted;
                result += dbContext.SaveChanges();
            }
            return result;
        }

        /// <summary>
        /// 显示最近阅读
        /// </summary>
        /// <returns></returns>
        public List<HistoricalReadings> Query()
        {
            var linq = from h in dbContext.HistoricalReadings.ToList()
                       join n in dbContext.Novels.ToList() on
                       h.NoveId equals n.NovelId
                       join u in dbContext.Users.ToList() on
                       h.UserId equals u.UserId
                       select new HistoricalReadings
                       {
                           NoveId = h.NoveId,
                           UserId = h.UserId,
                           NovelName = n.NovelName,
                           ImgPath = n.ImgPath
                       };
            return linq.ToList();
        }

        public HistoricalReadings QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(HistoricalReadings t)
        {
            throw new NotImplementedException();
        }
    }
}
