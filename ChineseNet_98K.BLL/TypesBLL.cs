using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：小说类型业务逻辑层
    /// ** 创始时间：2018-11-20
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class TypesBLL : ITypes_BLL
    {
        private ITypes_DAL iTypes_DAL;
        public TypesBLL(ITypes_DAL _iTypes_DAL)
        {
            iTypes_DAL = _iTypes_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Add(Types t)
        {
            var result = iTypes_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="Ids">权限ID集合</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(string Ids)
        {
            var result = iTypes_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// <summary>
        /// 获取类型信息
        /// </summary>
        /// <returns>返回</returns>
        public List<Types> Query()
        {
            var result = iTypes_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据Id获取类型信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回信息</returns>
        public Types QueryById(int Id)
        {
            var result = iTypes_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        public int Update(Types t)
        {
            var result = iTypes_DAL.Update(t);
            return result;
        }
    }
}
