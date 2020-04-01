using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StandaloneLessons.Models;

namespace StandaloneLessons
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
            services.AddControllersWithViews();

            services.AddScoped<IRepository, Repository>();
            /*
             * SingleTon(여기에 속한 메서드들이 프로그램 시작과 동시에 등록이 됨)
             *  - Singleton lifetime services are created the first time they are requested. Every subsequent request uses
             *   that same instance.
             *   
             * Scope(요청이 들어오면 속한 메서드들이 시작됨)
             *  - Scoped lifetime services are created once per client request, so each new http request creates a new scoped
             *  service.
             *  
             * Transient(매번 요청이 됨)
             *  - Transient lifetime services are created each time they are requested from the service container. With a transient
             *  service a new instance is provided everytime a service instance is requested whether it is in the scope
             *  of the same http request or across different http request
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
