using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Common.Web;
using Students.Shared;

namespace Students.Webpage.Services
{
    public class LoginService
    {
        public bool IsLoggedIn { get; set; }

        private readonly HttpClient HttpClient;

        public LoginService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<Response> Login(Login request)
        {
            var response = await HttpClient.PostAsJsonAsync("users", request);

            if (response.IsSuccessStatusCode)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await response.Content.ReadAsStringAsync());
                IsLoggedIn = true;
            }

            return Response.Success;
        }
    }
}
