using Microsoft.Extensions.DependencyInjection;

namespace ChineseNet_98K.Reception
{
    using BLL;
    using DAL;
    using IBLL;
    using IDAL;

    public static class DI
    {
        public static void AddScored(this IServiceCollection service)
        {
            //BLL层注入
            service.AddScoped<IBookReview_Answers_BLL, BookReview_Answers_BLL>();
            service.AddScoped<IBookReviews_BLL, BookReviewsBLL>();
            service.AddScoped<IBooshelf_BLL, BooshelfsBLL>();
            service.AddScoped<IChapters_BLL, ChaptersBLL>();
            service.AddScoped<IAuthorLR_BLL, AuthorLR_BLL>();
            service.AddScoped<IApprovals_BLL, ApprovalsBLL>();
            service.AddScoped<IVolumes_BLL, VolumesBLL>();
            service.AddScoped<IUsers_BLL, UsersBLL>();
            service.AddScoped<INovels_BLL, NovelsBLL>();
            service.AddScoped<ITypes_BLL, TypesBLL>();
            service.AddScoped<IAdmin_Users_BLL, Admin_UsersBLL>();
            service.AddScoped<IRoles_BLL, RolesBLL>();
            service.AddScoped<IPermissions_BLL, PermissionsBLL>();
            service.AddScoped<IUsers_BLL, UsersBLL>();
            service.AddScoped<IUsers_BLL, UsersBLL>();
            service.AddScoped<IMessages_BLL, MessagesBLL>();
            service.AddScoped<IContracts_BLL, ContractsBLL>();
            service.AddScoped<IGrades_BLL, GradesBLL>();
            service.AddScoped<IGrade_Users_BLL, Grade_UsersBLL>();
            service.AddScoped<IHistoricalReadings_BLL, HistoricalReadingsBLL>();
            service.AddScoped<IBooshelf_BLL, BooshelfsBLL>();
            service.AddScoped<IProfits_BLL, ProfitsBLL>();
            service.AddScoped<IAuthor_attendances_BLL, Author_attendancesBLL>();
            service.AddScoped<IIncomeDetails_BLL, IncomeDetailsBLL>();
            service.AddScoped<IWallets_BLL, WalletsBLL>();
            service.AddScoped<ISubscribes_BLL, SubscribesBLL>();
            service.AddScoped<IConsumptions_BLL, ConsumptionsBLL>();
            
            service.AddScoped<IRanking_BLL, RankingBLL>();
            //DAL层注入
            service.AddScoped<IBooshelfs_DAL, BooshelfsDAL>();
            service.AddScoped<IBooshelfs_DAL, BooshelfsDAL>();
            service.AddScoped<IChapters_DAL, ChaptersDAL>();
            service.AddScoped<IAuthorLR_DAL, AuthorLR_DAL>();
            service.AddScoped<IApprovals_DAL, ApprovalsDAL>();
            service.AddScoped<IBookReview_Answers_DAL, BookReview_Answers_DAL>();
            service.AddScoped<IBookReviews_DAL, BookReviewsDAL>();
            service.AddScoped<IVolumes_DAL, VolumesDAL>();
            service.AddScoped<IUsers_DAL, UsersDAL>();
            service.AddScoped<INovels_DAL, NovelsDAL>();
            service.AddScoped<ITypes_DAL, TypesDAL>();
            service.AddScoped<IAdmin_Users_DAL, Admin_UsersDAL>();
            service.AddScoped<IRoles_DAL, RolesDAL>();
            service.AddScoped<IPermissions_DAL, PermissionsDAL>();
            service.AddScoped<IUsers_DAL, UsersDAL>();
            service.AddScoped<IMessages_DAL, MessagesDAL>();
            service.AddScoped<IContracts_DAL, ContractsDAL>();
            service.AddScoped<IGrades_DAL, GradesDAL>();
            service.AddScoped<IGrade_Users_DAL, Grade_UsersDAL>();
            service.AddScoped<IHistoricalReadings_DAL, HistoricalReadingsDAL>();
            service.AddScoped<IProfits_DAL, ProfitsDAL>();
            service.AddScoped<IIncomeDetails_DAL, IncomeDetailsDAL>();
            service.AddScoped<IAuthor_attendances_DAL, Author_attendancesDAL>();
            service.AddScoped<ISubscribes_DAL, SubscribesDAL>();
            service.AddScoped<IWallets_DAL, WalletsDAL>();
            service.AddScoped<IConsumptions_DAL, ConsumptionsDAL>();
            service.AddScoped<IRanking_DAL, RankingDAL>();
        }
    }
}
