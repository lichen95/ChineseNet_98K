using System;
using System.Collections.Generic;
using System.Text;

namespace ChineseNet_98K.IBLL
{
    using Entity;

    /// <summary>
    /// ** 描述：作者考勤BLL接口层
    /// ** 创始时间：2018-12-03
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public interface IAuthor_attendances_BLL:IBase_BLL<Author_attendances>
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<Author_attendances> Query();
    }
}
