using System;
using System.Collections.Generic;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IBLL;
    using IDAL;

    /// <summary>
    /// ** 描述：我的消息DAL层
    /// ** 创始时间：2018-11-23
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class MessagesBLL : IMessages_BLL
    {
        private IMessages_DAL iMessages_DAL;
        public MessagesBLL(IMessages_DAL _iMessages_DAL)
        {
            iMessages_DAL = _iMessages_DAL;
        }

        /// <summary>
        /// 添加消息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Messages t)
        {
            var result = iMessages_DAL.Add(t);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Delete(string Ids)
        {
            var result = iMessages_DAL.Delete(Ids);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Messages> Query()
        {
            var result = iMessages_DAL.Query();
            return result;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Messages QueryById(int Id)
        {
            var result = iMessages_DAL.QueryById(Id);
            return result;
        }

        public int Update(Messages t)
        {
            throw new NotImplementedException();
        }
    }
}
