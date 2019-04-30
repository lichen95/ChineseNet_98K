using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：角色BLL类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class RolesBLL : IRoles_BLL
    {
        private IRoles_DAL IRoles_DAL;
        public RolesBLL(IRoles_DAL _IRoles_DAL)
        {
            IRoles_DAL = _IRoles_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Roles t)
        {
            var result = IRoles_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var result = IRoles_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns>返回list</returns>
        public List<Roles> Query()
        {
            var result = IRoles_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">权限ID</param>
        /// <returns>返回信息</returns>
        public Roles QueryById(int Id)
        {
            var result = IRoles_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Roles t)
        {
            var result = IRoles_DAL.Update(t);
            return result;
        }
    }
}
