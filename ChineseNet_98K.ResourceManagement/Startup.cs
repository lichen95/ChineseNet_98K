using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChineseNet_98K.ResourceManagement.Content;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChineseNet_98K.ResourceManagement
{
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

            //图片选项
            services.Configure<PictureOptions>(Configuration.GetSection("PictureOptions"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            services.AddCors(options => options.AddPolicy("CorsSample",
       p => p.WithOrigins("http://127.0.0.1:8056").AllowAnyMethod().AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseCors("CorsSample");


            app.UseMvc();
           
        }
    }
}
