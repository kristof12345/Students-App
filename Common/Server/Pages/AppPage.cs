using System.Threading.Tasks;
using LoginApp.Webpage.Services;
using Microsoft.AspNetCore.Components;

namespace WebApp.Server.Pages
{
    public class AppPage : ComponentBase
    {
        [Inject]
        protected LoginService LoginService { get; set; }

        protected override void OnInitialized()
        {
            LoginService.LoginEvent += OnLogin;
        }

        private async Task OnLogin()
        {
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
