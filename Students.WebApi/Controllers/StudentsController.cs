using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Database.Entities;
using Students.Logic;
using Students.Logic.Models;
using Students.WebApi.Attributes;

namespace Students.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService StudentService;

        public StudentsController(StudentService studentService)
        {
            StudentService = studentService;
        }

        [HttpPost]
        public async Task CreateStudent([FromBody] Student student)
        {
            await StudentService.AddStudent(student);
        }

        [HttpGet]
        public Task<IEnumerable<Student>> ListStudents()
        {
            return StudentService.ListStudents();
        }

        [HttpGet("statistics")]
        public Task<IEnumerable<Statictic>> ListStatistics()
        {
            return StudentService.ListStatistics();
        }

        [Authorize]
        [HttpPost("{id}")]
        public Task AddGrade([FromRoute] long id, [FromBody] Grade grade)
        {
            return StudentService.AddGrade(id, grade);
        }
    }
}
