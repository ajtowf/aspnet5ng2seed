using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet5ng2seed.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace aspnet5ng2seed
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                });

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(
                config =>
                {
                    config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<Seeder>();
        }

        public void Configure(
            IApplicationBuilder app,
            Seeder seeder)
        {
            app.UseIISPlatformHandler();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseIdentity();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}");
            });

            seeder.EnsureSeedData().Wait();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
