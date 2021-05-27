using System.Collections.Generic;
using System.Net.Http;
using Students.Shared;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Common.Web;

namespace Students.Webpage.Services
{
    public class StudentService
    {
        private readonly HttpClient HttpClient;

        public StudentService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<Student>> ListStudents()
        {
            var response = await HttpClient.GetAsync("students");
            return await response.Content.ReadAsAsync<List<Student>>();
        }

        public async Task<List<Statistic>> ListStatistics()
        {
            var response = await HttpClient.GetAsync("students/statistics");
            return await response.Content.ReadAsAsync<List<Statistic>>();
        }

        public async Task<Response> Create(Student student)
        {
            await HttpClient.PostAsJsonAsync("students", student);
            return Response.Success;
        }

        public async Task<Response> AddGrade(long id, Grade grade)
        {
            var response = await HttpClient.PostAsJsonAsync("students/" + id , grade);
            if (response.IsSuccessStatusCode) return Response.Success;
            return new Response(response.StatusCode.ToString());
        }
    }
}
