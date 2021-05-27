using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Common.Application.Models;
using Common.Web;
using InvestmentApp.Webpage.Services;
using LoginApp.Webpage.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;

namespace WebApp.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDA3ODkwQDMxMzgyZTM0MmUzME9Oalc5SERPZklFbklFUUkzRGlkb1cybjV5ZVVmdVB3YkFBSytrYTBCMDA9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var services = builder.Services;

            services.AddSingleton(builder.Configuration.GetSection("ServerSettings").Get<ServerSettings>());

            services.AddBlazoredLocalStorage();
            services.AddSyncfusionBlazor();

            services.AddScoped<AppService>();
            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();

            services.AddScoped<LoginService>();
            services.AddScoped<UserService>();
            services.AddScoped<FavouriteService>();

            //Add services
            services.AddScoped<StockService>();
            services.AddScoped<PortfolioService>();
            services.AddScoped<FavouriteService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<CurrencyService>();
            services.AddScoped<AdminService>();
            services.AddScoped<CommonService>();
            services.AddScoped<IndicatorService>();

            await builder.Build().RunAsync();
        }
    }
}
