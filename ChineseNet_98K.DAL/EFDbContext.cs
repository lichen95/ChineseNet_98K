namespace ChineseNet_98K.DAL
{
    using Entity;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ** 描述：EF上下文类
    /// ** 创始时间：2018-11-19
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 用户等级关联表
        /// </summary>
        public DbSet<Grade_Users> Grade_Users { get; set; }

        /// <summary>
        /// 申请签约表
        /// </summary>
        public DbSet<Contracts> Contracts { get; set; }

        /// <summary>
        /// 书评回复表
        /// </summary>
        public DbSet<BookReview_Answers> BookReview_Answers { get; set; }

        /// <summary>
        /// 前台用户表
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// 后台用户表
        /// </summary>
        public DbSet<Admin_Users> Admin_Users { get; set; }

        /// <summary>
        /// 答案表
        /// </summary>
        public DbSet<Answers> Answers { get; set; }

        /// <summary>
        ///书评表
        /// </summary>
        public DbSet<BookReviews> BookReviews { get; set; }

        /// <summary>
        ///书架分组表 
        /// </summary>
        public DbSet<BookshelfGroups> BookshelfGroups { get; set; }

        /// <summary>
        /// 书架表
        /// </summary>
        public DbSet<Booshelfs> Booshelfs { get; set; }

        /// <summary>
        ///  小说章节表
        /// </summary>
        public DbSet<Chapters> Chapters { get; set; }

        /// <summary>
        /// 消费表
        /// </summary>
        public DbSet<Consumptions> Consumptions { get; set; }

        /// <summary>
        /// 礼物表
        /// </summary>
        public DbSet<Gifts> Gifts { get; set; }

        /// <summary>
        /// 用户等级表
        /// </summary>
        public DbSet<Grades> Grades { get; set; }

        /// <summary>
        /// 历史阅读表
        /// </summary>
        public DbSet<HistoricalReadings> HistoricalReadings { get; set; }

        /// <summary>
        /// 消息表
        /// </summary>
        public DbSet<Messages> Messages { get; set; }

        /// <summary>
        /// 小说信息表
        /// </summary>
        public DbSet<Novels> Novels { get; set; }

        /// <summary>
        /// 权限角色表
        /// </summary>
        public DbSet<Permission_Roles> Permission_Roles { get; set; }

        /// <summary>
        /// 权限表
        /// </summary>
        public DbSet<Permissions> Permissions { get; set; }

        /// <summary>
        /// 收益表
        /// </summary>
        public DbSet<Profits> Profits { get; set; }

        /// <summary>
        /// 推荐表
        /// </summary>
        public DbSet<Recommends> Recommends { get; set; }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Roles> Roles { get; set; }

        /// <summary>
        ///  用户安全问题表
        /// </summary>
        public DbSet<SafetyProblems> SafetyProblems { get; set; }

        /// <summary>
        ///   订阅表
        /// </summary>
        public DbSet<Subscribes> Subscribes { get; set; }

        /// <summary>
        /// 小说类型表
        /// </summary>
        public DbSet<Types> Types { get; set; }

        /// <summary>
        /// 用户角色表
        /// </summary>
        public DbSet<User_Roles> User_Roles { get; set; }

        /// <summary>
        /// 用户信息表
        /// </summary>
        public DbSet<Authors> Authors { get; set; }

        /// <summary>
        ///   粉丝等级表
        /// </summary>
        public DbSet<Vermicellis> Vermicellis { get; set; }

        /// <summary>
        ///  分卷表
        /// </summary>
        public DbSet<Volumes> Volumes { get; set; }

        /// <summary>
        /// 钱包表
        /// </summary>
        public DbSet<Wallets> Wallets { get; set; }

        /// <summary>
        /// 审批表 
        /// </summary>
        public DbSet<Approvals> Approvals { get; set; }

        /// <summary>
        /// 书签表
        /// </summary>
        public DbSet<Bookmarks> Bookmarks { get; set; }

        /// <summary>
        /// 稿费明细表
        /// </summary>
        public DbSet<IncomeDetails> IncomeDetails { get; set; }

        /// <summary>
        /// 作者考勤表
        /// </summary>
        public DbSet<Author_attendances> Author_attendances { get; set; }

        /// <summary>
        /// 小说章节帮助类
        /// </summary>
        public DbSet<ChapterHelper> ChapterHelpers { get; set; }
    }
}
