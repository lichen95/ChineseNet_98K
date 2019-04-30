using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChineseNet_98K.Reception
{
    using Alipay.AopSdk.AspnetCore;
    using Alipay.AopSdk.F2FPay.AspnetCore;
    using ChineseNet_98K.DAL;
    using ChineseNet_98K.Reception.Content;
    using ChineseNet_98K.Reception.Service;
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Rotativa.AspNetCore;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IEsClientProvider, EsClientProvider>();

            //redis配置
            //RedisConfig.Connection = Configuration.GetSection("RedisConfig")["Connection"];
            //RedisConfig.DefaultDatabase = Convert.ToInt32(Configuration.GetSection("RedisConfig")["DefaultDatabase"]);
            //RedisConfig.InstanceName = Configuration.GetSection("RedisConfig")["InstanceName"];
            //CommonManager.CacheObj.GetMessage<RedisCacheHelper>();

            //数据库连接字符串
            var connection = Configuration.GetConnectionString("conn");
            //注入EFCore上下文
            services.AddDbContext<EFDbContext>(options =>
                options.UseSqlServer(connection, b => b.MigrationsAssembly("ChineseNet_98K.Reception")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //添加系统配置
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddScored();//使用DI注入

            services.AddHttpContextAccessor();

            //配置alipay服务
            ConfigureAlipay(services);
        }

        private void ConfigureAlipay(IServiceCollection services)
        {
            var alipayOptions = Configuration.GetSection("Alipay").Get<AlipayOptions>();
            //检查RSA私钥
            AlipayConfigChecker.Check(alipayOptions.SignType, alipayOptions.PrivateKey);
            services.AddAlipay(options => options.SetOption(alipayOptions)).AddAlipayF2F();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticHttpContext();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            RotativaConfiguration.Setup(env);
        }
    }
}
