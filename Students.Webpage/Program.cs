using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Students.Webpage.Services;
using Syncfusion.Blazor;

namespace Students.Webpage
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDA3ODkwQDMxMzgyZTM0MmUzME9Oalc5SERPZklFbklFUUkzRGlkb1cybjV5ZVVmdVB3YkFBSytrYTBCMDA9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });

            builder.Services.AddApiAuthorization();
            var services = builder.Services;

            services.AddSyncfusionBlazor();

            services.AddScoped<AppService>();
            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();

            services.AddSingleton<LoginService>();
            services.AddSingleton<StudentService>();

            await builder.Build().RunAsync();
        }
    }
}
