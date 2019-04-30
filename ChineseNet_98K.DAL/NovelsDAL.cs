using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// ** 描述：小说信息DAL层
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class NovelsDAL : INovels_DAL
    {
        private readonly EFDbContext dbContext;
        public NovelsDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Novels t)
        {
            var parms = new[] {
                    new SqlParameter("@NovelNum",t.NovelNum),
                    new SqlParameter("@NovelName",t.NovelName),
                    new SqlParameter("@AuthorId",t.AuthorId),
                    new SqlParameter("@NovelDesc",t.NovelDesc),
                    new SqlParameter("@LabelName",t.LabelName),
                    new SqlParameter("@ImgPath",t.ImgPath),
                    new SqlParameter("@AuthorMessage",t.AuthorMessage),
                    new SqlParameter("@TypeIdOne",t.TypeIdOne),
                    new SqlParameter("@TypeIdTwo",t.TypeIdTwo),
                    new SqlParameter("@State",t.State),
                    new SqlParameter("@CreateDate",t.CreateDate),
                    new SqlParameter("@identity",0)
                };
            parms[11].Direction = ParameterDirection.Output;
            var result = dbContext.Database.ExecuteSqlCommand("exec p_CreateNovels_Chapters @NovelNum,@NovelName,@AuthorId,@NovelDesc,@LabelName,@ImgPath,@AuthorMessage,@TypeIdOne,@TypeIdTwo,@State,@CreateDate,@identity output", parms);
            return Convert.ToInt32(parms[11].Value);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="Ids">权限ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var arr = Ids.Split(',');
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var parms = new[] {
                        new SqlParameter("@NovelId",Convert.ToInt32(arr[i]))
                };
                result += dbContext.Database.ExecuteSqlCommand("exec p_DeleteNovels @NovelId", parms);
            }
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回</returns>
        public List<Novels> Query()
        {
            var linq = from n in dbContext.Novels.ToList()
                       join t1 in dbContext.Types.ToList() on
                       n.TypeIdOne equals t1.TypeId
                       join t2 in dbContext.Types.ToList() on
                       n.TypeIdTwo equals t2.TypeId
                       join u in dbContext.Authors.ToList() on
                       n.AuthorId equals u.AuthorId
                       select new Novels
                       {
                           NovelId = n.NovelId,
                           NovelNum = n.NovelNum,
                           NovelName = n.NovelName,
                           NovelDesc = n.NovelDesc,
                           LabelName = n.LabelName,
                           ImgPath = n.ImgPath,
                           AuthorId = u.AuthorId,
                           TypeIdOne = n.TypeIdOne,
                           TypeIdTwo = n.TypeIdTwo,
                           TypeNameOne = t1.TypeName,
                           TypeNameTwo = t2.TypeName,
                           CreateDate = n.CreateDate,
                           UserName = u.Pseudonym,
                           State=n.State,
                           WordSize=n.WordSize
                       };
            return linq.ToList();
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回信息</returns>
        public Novels QueryById(int Id)
        {
            var result = dbContext.Novels.Find(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Novels t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
