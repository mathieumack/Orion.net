using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orion.Net.Hubs;
using System.Configuration;

namespace Orion.Net
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSignalR().AddAzureSignalR(ConfigurationManager.AppSettings["AzureSignalRConnection"].ToString());
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = myKeyVaultConfigService.GetByKey("redis-connectionstring").Result;
            //    options.ConfigurationOptions = new ConfigurationOptions()
            //    {
            //        ConnectRetry = 3,
            //        ReconnectRetryPolicy = new LinearRetry(1500)
            //    };
            //    options.InstanceName = "myawesome-api";
            //});
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
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<OrionHub>("/orionhub");
            });

            //app.UseAzureSignalR(routes =>
            //{
            //    routes.MapHub<OrionHub>("/orionhub");
            //});

            app.UseNodeModules();
        }
    }
}
