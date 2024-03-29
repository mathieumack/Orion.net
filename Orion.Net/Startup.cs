﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orion.Net.CacheManagement;
using Orion.Net.Hubs;
using Orion.Net.Interface;

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

            //Comment this region to disable the authentification
            #region Authentification with Azure Active Directory

            //For AAD : get secret values from Key vault for the configuration in appsettings.json
            //Configuration["AzureAd:TenantId"] = Configuration["AADTenantId"];
            //Configuration["AzureAd:ClientId"] = Configuration["AADClientId"];

            services.AddAuthentication(AzureADDefaults.AuthenticationScheme);
            //    .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.AddMvc(options =>
                {
                    //var policy = new AuthorizationPolicyBuilder()
                    //                .RequireAuthenticatedUser()
                    //                .Build();
                    //options.Filters.Add(new AuthorizeFilter(policy));
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #endregion

            #region SignalR

            //SignalR Azure Service
            //services.AddSignalR().AddAzureSignalR(Configuration["signalr"]);

            //SignalR without Azure service
            services.AddSignalR();

            #endregion

            #region CacheManagement

            //Switch between LocalCache and RedisCache in function of your need
            services.AddSingleton(typeof(ICacheManagement), typeof(LocalCache));

            #endregion

            services.AddControllersWithViews();
            services.AddRazorPages();

            #region Insights

            //Configuration["ApplicationInsights:InstrumentationKey"] = Configuration["Insights"];
            services.AddApplicationInsightsTelemetry();

            #endregion
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

            //Comment this region to disable Authentification
            #region Authentification

            //app.UseAuthentication();

            #endregion

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<OrionHub>("/orionhub");
            });
        }
    }
}
