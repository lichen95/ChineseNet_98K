using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ChineseNet_98K.Entity
{
    /// <summary>
    /// 作者考勤表
    /// </summary>
    public class Author_attendances
	{
		public Author_attendances()
		{}
		/// <summary>
		/// 主键ID
		/// </summary>
		[Key]
		public int Author_attendanceId
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
		/// 状态 1-10个状态1000-10000字
		/// </summary>
		public int State
		{
			get;set;
		}

        /// <summary>
        /// 小说ID
        /// </summary>
        public int NovelId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
		{
			get;set;
		}
	}
}

