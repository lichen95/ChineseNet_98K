using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using Entity;
    using IDAL;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ** 描述：小说类型数据访问层
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class TypesDAL : ITypes_DAL
    {
        private readonly EFDbContext dbContext;
        public TypesDAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Types t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return result;
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
                var t = QueryById(Convert.ToInt32(arr[i]));
                dbContext.Entry(t).State = EntityState.Deleted;
                result += dbContext.SaveChanges();
            }
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回</returns>
        public List<Types> Query()
        {
            var result = dbContext.Types.ToList();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回信息</returns>
        public Types QueryById(int Id)
        {
            var result = dbContext.Types.Find(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Types t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
