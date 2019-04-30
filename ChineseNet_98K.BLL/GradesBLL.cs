using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：等级管理BLL层
    /// ** 创始时间：2018-11-28
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class GradesBLL:IGrades_BLL
    {
        private IGrades_DAL iGrades_DAL;
        public GradesBLL(IGrades_DAL _iGrades_DAL)
        {
            iGrades_DAL = _iGrades_DAL;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Grades t)
        {
            var result = iGrades_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iGrades_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Grades> Query()
        {
            var result = iGrades_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Grades QueryById(int Id)
        {
            var result = iGrades_DAL.QueryById(Id);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Grades t)
        {
            var result = iGrades_DAL.Update(t);
            return result;
        }
    }
}
