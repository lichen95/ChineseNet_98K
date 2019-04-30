using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ChineseNet_98K.Entity
{
    /// <summary>
    ///稿费明细表
    /// </summary>
    public class IncomeDetails
	{
		public IncomeDetails()
		{}
		/// <summary>
		/// 主键ID
		/// </summary>
		[Key]
		public int IncomeDetailId
		{
			get;set;
		}
		/// <summary>
		/// 收入类型  1打赏2vip章节3全勤奖4排行榜奖励
		/// </summary>
		public int Types
		{
			get;set;
		}
		/// <summary>
		/// 小说ID
		/// </summary>
		public int NovelId
		{
			get;set;
		}
		/// <summary>
		/// 稿酬
		/// </summary>
		public decimal ProfitNum
		{
			get;set;
		}
		/// <summary>
		/// 作者ID
		/// </summary>
		public int AuthorId
		{
			get;set;
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateDate
		{
			get;set;
		}
	}
}

