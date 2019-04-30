namespace ChineseNet_98K.IDAL
{
    /// <summary>
    /// ** 描述：DAL接口
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IBase_DAL<T> where T : class, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        int Add(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">id集合</param>
        /// <returns>返回受影响行数</returns>
        int Delete(string Ids);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t">实体</param>
        /// <returns>返回受影响行数</returns>
        int Update(T t);

        /// <summary>
        /// 根据ID查询实体信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>返回实体信息</returns>
        T QueryById(int Id);
    }
}
