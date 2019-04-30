using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using ChineseNet_98K.IBLL;
    using ChineseNet_98K.IDAL;
    using Entity;

    /// <summary>
    /// ** 描述：作者BLL
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class AuthorLR_BLL : IAuthorLR_BLL
    {
        public IAuthorLR_DAL _IAuthorLR_DAL;

        public AuthorLR_BLL(IAuthorLR_DAL _iAuthorLR_dal)
        {
            _IAuthorLR_DAL = _iAuthorLR_dal;
        }

        /// <summary>
        /// 作者注册
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Authors t)
        {
            var result = _IAuthorLR_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 作者密码登录
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Authors AuthorLogin(string pwd, int UserId)
        {
            var result = _IAuthorLR_DAL.AuthorLogin(pwd, UserId);
            return result;
        }

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
            var result = _IAuthorLR_DAL.Query();
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Authors QueryById(int Id)
        {
            var result = _IAuthorLR_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Authors t)
        {
            var result = _IAuthorLR_DAL.Update(t);
            return result;
        }

        /// <summary>
        /// 作者修改密码
        /// </summary>
        /// <param name="Aid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Uptpwd(Authors t)
        {
            var result = _IAuthorLR_DAL.Uptpwd(t);
            return result;
        }
    }
}
