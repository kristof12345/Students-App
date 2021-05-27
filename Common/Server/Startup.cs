using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Syncfusion.Blazor;
using Microsoft.Extensions.Hosting;
using Common.Web;
using LoginApp.Webpage.Services;
using InvestmentApp.Webpage.Services;
using Common.Application.Models;

namespace WebApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetSection("ServerSettings").Get<ServerSettings>());

            services.AddSignalR(e => { e.MaximumReceiveMessageSize = 102400000; });
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddBlazoredLocalStorage();
            services.AddSyncfusionBlazor();

            services.AddScoped<AppService>();
            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();

            services.AddScoped<LoginService>();
            services.AddScoped<UserService>();

            //Add services
            services.AddScoped<StockService>();
            services.AddScoped<PortfolioService>();
            services.AddScoped<FavouriteService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<CurrencyService>();
            services.AddScoped<AdminService>();
            services.AddScoped<CommonService>();
            services.AddScoped<IndicatorService>();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDA3ODkwQDMxMzgyZTM0MmUzME9Oalc5SERPZklFbklFUUkzRGlkb1cybjV5ZVVmdVB3YkFBSytrYTBCMDA9");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/Host");
            });
        }
    }
}
