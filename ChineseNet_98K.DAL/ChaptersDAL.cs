using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Reflection;

    /// <summary>
    /// ** 描述：文章信息DAL层
    /// ** 创始时间：2018-11-23
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class ChaptersDAL : IChapters_DAL
    {
        private readonly EFDbContext dbContext;
        public ChaptersDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增章节
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Chapters t)
        {
            var parms = new[] {
                new SqlParameter("@NovelId",t.NovelId),
                new SqlParameter("@VolumeId",t.VolumeId),
                new SqlParameter("@ChapterName",t.ChapterName),
                new SqlParameter("@ChapterContent",t.ChapterContent),
                new SqlParameter("@IsVIP",t.IsVIP),
                new SqlParameter("@CreateDate",t.CreateDate),
                new SqlParameter("@State",t.State),
                new SqlParameter("@AuthorDesc",t.AuthorDesc),
                new SqlParameter("@WordSize",t.WordSize)
            };
            var sql = "insert into Chapters" + t.NovelId + "(NovelId,VolumeId,ChapterName,ChapterContent,IsVIP,CreateDate,State,AuthorDesc,WordSize) values(@NovelId,@VolumeId,@ChapterName,@ChapterContent,@IsVIP,@CreateDate,@State,@AuthorDesc,@WordSize)";
            var result = dbContext.Database.ExecuteSqlCommand(sql, parms);
            return result;
        }

        /// <summary>
        /// 根据小说id显示草稿箱
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        public Chapters ChaChapters(int NovelId)
        {
            var result = dbContext.Chapters.Find(NovelId);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var t = Query(Convert.ToInt32(arr[i]));
                dbContext.Entry(t).State = EntityState.Deleted;
                result += dbContext.SaveChanges();
            }
            return result;
        }

        /// <summary>
        /// 获取章节信息
        /// </summary>
        /// <returns></returns>
        public List<Chapters> Query(int novelId)
        {
            var parms = new[] {
                new SqlParameter("@novelId",novelId)
            };
            var result = dbContext.Chapters.AsNoTracking().FromSql("exec dbo.p_ShowChapters @novelId", parms);
            return result.ToList();
        }

        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Chapters QueryById(int Id)
        {
            var result = dbContext.Chapters.Find(Id);
            return result;
        }

        /// <summary>
        /// 小说详情
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        public List<Chapters> Show(int NovelId)
        {
            var list = Query(NovelId).Where(m => m.State != 0).ToList();
            return list;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Chapters t)
        {
            var parms = new[] {
                new SqlParameter("@ChapterId",t.ChapterId),
                new SqlParameter("@NovelId",t.NovelId),
                new SqlParameter("@VolumeId",t.VolumeId),
                new SqlParameter("@ChapterName",t.ChapterName),
                new SqlParameter("@ChapterContent",t.ChapterContent),
                new SqlParameter("@IsVIP",t.IsVIP),
                new SqlParameter("@CreateDate",t.CreateDate),
                new SqlParameter("@State",t.State),
                new SqlParameter("@AuthorDesc",t.AuthorDesc),
                new SqlParameter("@WordSize",t.WordSize)
            };
            var sql = "update Chapters" + t.NovelId + " set  NovelId=@NovelId,VolumeId=@VolumeId,ChapterName=@ChapterName,ChapterContent=@ChapterContent,IsVIP=@IsVIP,CreateDate=@CreateDate,State=@State,AuthorDesc=@AuthorDesc,WordSize=@WordSize where ChapterId=@ChapterId";
            var result = dbContext.Database.ExecuteSqlCommand(sql, parms);
            return result;
        }

        /// <summary>
        /// 草稿箱删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DelChapters(string id, int ids)
        {
            string sql = "delete Chapters" + id + " where ChapterId=" + ids;
            return dbContext.Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        /// 草稿箱反填
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int FtChapters(string id, int ids)
        {
            string sql = "select * from Chapters" + id + " where ChapterId=" + ids;
            return dbContext.Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        /// 获取小说章节信息
        /// </summary>
        /// <param name="NovelId"></param>
        /// <returns></returns>
        public List<ChapterHelper> All(int NovelId)
        {
            string sql = "SELECT ROW_NUMBER() OVER(ORDER BY CreateDate ASC) AS rowId,* FROM dbo.Chapters" + NovelId;
            var result = dbContext.ChapterHelpers.AsNoTracking().FromSql(sql);
            return result.ToList();
        }

        #region  老方法
        //public IEnumerable<T> ToCollection<T>(DataTable dt) where T : new()
        //{
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return Enumerable.Empty<T>();
        //    }
        //    IList<T> ts = new List<T>();
        //    // 获得此模型的类型 
        //    Type type = typeof(T);
        //    string tempName = string.Empty;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        T t = new T();
        //        PropertyInfo[] propertys = t.GetType().GetProperties();
        //        foreach (PropertyInfo pi in propertys)
        //        {
        //            tempName = pi.Name;
        //            //检查DataTable是否包含此列（列名==对象的属性名）     
        //            if (dt.Columns.Contains(tempName))
        //            {
        //                // 判断此属性是否有Setter   
        //                if (!pi.CanWrite) continue;//该属性不可写，直接跳出   
        //                object value = dr[tempName];
        //                if (value != DBNull.Value)
        //                    pi.SetValue(t, value, null);
        //            }
        //        }
        //        ts.Add(t);
        //    }
        //    return ts;
        //}
        #endregion
    }
}