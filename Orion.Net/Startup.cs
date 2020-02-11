using Microsoft.AspNetCore.Authentication;
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
using Orion.Net.Hubs;

namespace Orion.Net
{
    public class Startup
    {
        private const string yes = "yes";

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

            #region AAD Authentification
            if (Configuration["Configuration:AuthentificationAAD"] == yes)
            {
                //For AAD : get secret values from Key vault for the configuration in appsettings.json
                Configuration["AzureAd:TenantId"] = Configuration["AADTenantId"];
                Configuration["AzureAd:ClientId"] = Configuration["AADClientId"];
                services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                        .AddAzureAD(options => Configuration.Bind("AzureAd", options));

                services.AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            }
            #endregion
            if (Configuration["Configuration:SignalRAzure"] == yes)
            {
                services.AddSignalR().AddAzureSignalR(Configuration["signalr"]);
            }
            else
            {
                services.AddSignalR();
            }

            Configuration["profiles:Orion.Net:environmentVariables:redis"] = (Configuration["Configuration:RedisAzure"] == yes) ? Configuration["redis"] : "https://localhost:6379/";

            services.AddControllersWithViews();
            services.AddRazorPages();

            Configuration["ApplicationInsights:InstrumentationKey"] = Configuration["Insights"];
            services.AddApplicationInsightsTelemetry();
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

            if (Configuration["Configuration:AuthentificationAAD"] == yes)
            {
                app.UseAuthentication();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<OrionHub>("/orionhub");
            });
        }
    }
}
