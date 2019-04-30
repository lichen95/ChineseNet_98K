using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：等级管理关联BLL层
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class Grade_UsersBLL : IGrade_Users_BLL
    {
        private IGrade_Users_DAL iGrade_Users_DAL;
        public Grade_UsersBLL(IGrade_Users_DAL _iGrade_Users_DAL)
        {
            iGrade_Users_DAL = _iGrade_Users_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Grade_Users t)
        {
            var result = iGrade_Users_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iGrade_Users_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Grade_Users> Query()
        {
            var result = iGrade_Users_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Grade_Users QueryById(int Id)
        {
            var result = iGrade_Users_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Grade_Users t)
        {
            var result = iGrade_Users_DAL.Update(t);
            return result;
        }
    }
}
