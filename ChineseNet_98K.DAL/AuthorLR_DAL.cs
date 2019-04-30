using System;
using System.Collections.Generic;
using System.Linq;

namespace ChineseNet_98K.DAL
{
    using ChineseNet_98K.IDAL;
    using Entity;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ** 描述：用户DAL
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class AuthorLR_DAL : IAuthorLR_DAL
    {
        private readonly EFDbContext dbContext;
        public AuthorLR_DAL(EFDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 作者注册
        /// </summary>
        /// <param name="t">用户实体类</param>
        /// <returns></returns>
        public int Add(Authors t)
        {
            dbContext.Entry(t).State = EntityState.Added;
            var result = dbContext.SaveChanges();
            return t.AuthorId;
        }

        /// <summary>
        /// 作者密码登录
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Authors AuthorLogin(string pwd, int UserId)
        {
            var result = dbContext.Authors.Where(m => m.Password.Equals(pwd) && m.UserId.Equals(UserId)).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 作者删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取作者信息
        /// </summary>
        /// <returns></returns>
        public List<Authors> Query()
        {
            var result = dbContext.Authors.ToList();
            return result;
        }

        /// <summary>
        /// 根据id获取作者信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Authors QueryById(int Id)
        {
            var result = dbContext.Authors.Find(Id);
            return result;
        }

        /// <summary>
        /// 更新作者信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Authors t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// 修改作者密码 
        /// </summary>
        /// <param name="Aid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Uptpwd(Authors t)
        {
            Authors model = dbContext.Authors.Find(t.AuthorId);
            model.Password = t.Password;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
