using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.BLL
{
    using Entity;
    using IDAL;
    using IBLL;
    using System.Linq;

    /// <summary>
    /// ** 描述：订阅章节DAL层
    /// ** 创始时间：2018-12-04
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class SubscribesBLL:ISubscribes_BLL
    {
        private ISubscribes_DAL iSubscribes_DAL;
        public SubscribesBLL(ISubscribes_DAL _iSubscribes_DAL)
        {
            iSubscribes_DAL = _iSubscribes_DAL;
        }

        /// <summary>
        /// 订阅章节
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Subscribes t)
        {
            var result = iSubscribes_DAL.Add(t);
            return result;
        }

        public int Delete(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Subscribes> Query()
        {
            var result = iSubscribes_DAL.Query();
            return result;
        }

        public Subscribes QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(Subscribes t)
        {
            throw new NotImplementedException();
        }
    }
}
