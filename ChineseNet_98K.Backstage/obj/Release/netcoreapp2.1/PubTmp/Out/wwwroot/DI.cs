using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChineseNet_98K.Backstage.wwwroot
{
    using BLL;
    using DAL;
    using IBLL;
    using IDAL;
    public static class DI
    {
        public static void AddScored(this IServiceCollection service)
        {
            service.AddScoped<IBooshelf_BLL, BooshelfsBLL>();
            service.AddScoped<IBooshelfs_DAL, BooshelfsDAL>();
            service.AddScoped<IBookReview_Answers_BLL, BookReview_Answers_BLL>();
            service.AddScoped<IBookReview_Answers_DAL, BookReview_Answers_DAL>();
            service.AddScoped<IBookReviews_BLL, BookReviewsBLL>();
            service.AddScoped<IBookReviews_DAL, BookReviewsDAL>();
            service.AddScoped<IChapters_BLL, ChaptersBLL>();
            service.AddScoped<IChapters_DAL, ChaptersDAL>();
            service.AddScoped<IAuthorLR_BLL, AuthorLR_BLL>();
            service.AddScoped<IAuthorLR_DAL, AuthorLR_DAL>();
            service.AddScoped<IApprovals_BLL, ApprovalsBLL>();
            service.AddScoped<IApprovals_DAL, ApprovalsDAL>();
            service.AddScoped<IVolumes_BLL, VolumesBLL>();
            service.AddScoped<IVolumes_DAL, VolumesDAL>();
            service.AddScoped<IUsers_BLL, UsersBLL>();
            service.AddScoped<IUsers_DAL, UsersDAL>();
            service.AddScoped<INovels_BLL, NovelsBLL>();
            service.AddScoped<INovels_DAL, NovelsDAL>();
            service.AddScoped<ITypes_BLL, TypesBLL>();
            service.AddScoped<ITypes_DAL, TypesDAL>();
            service.AddScoped<IAdmin_Users_BLL, Admin_UsersBLL>();
            service.AddScoped<IAdmin_Users_DAL, Admin_UsersDAL>();
            service.AddScoped<IRoles_BLL, RolesBLL>();
            service.AddScoped<IRoles_DAL, RolesDAL>();
            service.AddScoped<IPermissions_BLL, PermissionsBLL>();
            service.AddScoped<IPermissions_DAL, PermissionsDAL>();
            service.AddScoped<IUsers_BLL, UsersBLL>();
            service.AddScoped<IUsers_DAL, UsersDAL>();
            service.AddScoped<IMessages_BLL, MessagesBLL>();
            service.AddScoped<IMessages_DAL, MessagesDAL>();
            service.AddScoped<IContracts_BLL, ContractsBLL>();
            service.AddScoped<IContracts_DAL, ContractsDAL>();
            service.AddScoped<IGrades_BLL, GradesBLL>();
            service.AddScoped<IGrades_DAL, GradesDAL>();
            service.AddScoped<IGrade_Users_BLL, Grade_UsersBLL>();
            service.AddScoped<IGrade_Users_DAL, Grade_UsersDAL>();
            service.AddScoped<IHistoricalReadings_BLL, HistoricalReadingsBLL>();
            service.AddScoped<IHistoricalReadings_DAL, HistoricalReadingsDAL>();
            service.AddScoped<IProfits_BLL, ProfitsBLL>();
            service.AddScoped<IProfits_DAL, ProfitsDAL>();
            service.AddScoped<IAuthor_attendances_BLL, Author_attendancesBLL>();
            service.AddScoped<IAuthor_attendances_DAL, Author_attendancesDAL>();
            service.AddScoped<IIncomeDetails_BLL, IncomeDetailsBLL>();
            service.AddScoped<IIncomeDetails_DAL, IncomeDetailsDAL>();
            service.AddScoped<ISubscribes_BLL, SubscribesBLL>();
            service.AddScoped<ISubscribes_DAL, SubscribesDAL>();
            service.AddScoped<IConsumptions_BLL, ConsumptionsBLL>();
            service.AddScoped<IConsumptions_DAL, ConsumptionsDAL>();
        }
    }
}
