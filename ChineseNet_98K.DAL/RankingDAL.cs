using System;
using System.Collections.Generic;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public class RankingDAL : IRanking_DAL
    {
        public readonly EFDbContext dbContext;
        public RankingDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 收藏排行
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public List<Ranking> CollectionRanking(int Num)
        {
            try
            {
                var book = new[]{
                new SqlParameter("@num",Num)
                };
                DbConnection connection = dbContext.Database.GetDbConnection();
                DbCommand cmd = connection.CreateCommand();
                dbContext.Database.OpenConnection();
                cmd.CommandText = "[p_Collectionranking]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(book);
                DataTable dt = new DataTable();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                dbContext.Database.CloseConnection();
                return ToCollection<Ranking>(dt).ToList();
                //var result = dbContext.Booshelfs.AsNoTracking().FromSql("exec p_Collectionranking @num", book);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public IEnumerable<T> ToCollection<T>(DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return Enumerable.Empty<T>();
            }
            IList<T> ts = new List<T>();
            // 获得此模型的类型 
            Type type = typeof(T);
            string tempName = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    //检查DataTable是否包含此列（列名==对象的属性名）     
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter   
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出   
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
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
                var book = new[]{
                new SqlParameter("@num",Num)
                };
                DbConnection connection = dbContext.Database.GetDbConnection();
                DbCommand cmd = connection.CreateCommand();
                dbContext.Database.OpenConnection();
                cmd.CommandText = "[p_BookReview]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddRange(book);
                DataTable dt = new DataTable();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                dbContext.Database.CloseConnection();
                return ToCollection<Ranking>(dt).ToList();
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
                DbConnection connection = dbContext.Database.GetDbConnection();
                DbCommand cmd = connection.CreateCommand();
                dbContext.Database.OpenConnection();
                cmd.CommandText = "[proc_QuzhanMonth]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                dbContext.Database.CloseConnection();
                return ToCollection<Ranking>(dt).ToList();
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
                DbConnection connection = dbContext.Database.GetDbConnection();
                DbCommand cmd = connection.CreateCommand();
                dbContext.Database.OpenConnection();
                cmd.CommandText = "[proc_QuzhanWeek]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                dbContext.Database.CloseConnection();
                return ToCollection<Ranking>(dt).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 新书排行榜
        /// </summary>
        /// <returns></returns>
        public List<Ranking> NewbookRanking()
        {
            try
            {
                DbConnection connection = dbContext.Database.GetDbConnection();
                DbCommand cmd = connection.CreateCommand();
                dbContext.Database.OpenConnection();
                cmd.CommandText = "[proc_NewbookWeek]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                dbContext.Database.CloseConnection();
                return ToCollection<Ranking>(dt).ToList();
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
                var result = from n in dbContext.Novels.ToList()
                             join a in dbContext.Authors.ToList() on
                             n.AuthorId equals a.AuthorId
                             join t in dbContext.Types.ToList() on
                             n.TypeIdOne equals t.TypeId
                             select new Novels
                             {
                                 NovelId = n.NovelId,
                                 NovelNum = n.NovelNum,
                                 NovelName = n.NovelName,
                                 AuthorId = n.AuthorId,
                                 NovelDesc = n.NovelDesc,
                                 LabelName = n.LabelName,
                                 ImgPath = n.ImgPath,
                                 AuthorMessage = n.AuthorMessage,
                                 TypeIdOne = n.TypeIdOne,
                                 TypeIdTwo = n.TypeIdTwo,
                                 State = n.State,
                                 CreateDate = n.CreateDate,
                                 WordSize = n.WordSize,
                                 TypeNameOne=t.TypeName,
                                 Pseudonym=a.Pseudonym
                             };
                return result.OrderByDescending(m=>m.WordSize).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
