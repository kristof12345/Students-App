using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Students.Database.Entities;
using Students.Logic;

namespace Students.WebApi.SeedData
{
    public class SeedData
    {
        public static void Initialize(UserService userService, StudentService studentService)
        {
            SeedUserData(userService).Wait();
            SeedStudentData(studentService).Wait();
            SeedGradeData(studentService);
        }

        private static async Task SeedUserData(UserService userService)
        {
            await userService.Create(new IdentityUser
            {
                UserName = "admin",
            }, "edutest2021");
        }

        private static async Task SeedStudentData(StudentService studentService)
        {
            await studentService.AddStudent(new Student
            {
                Name = "Student1",
                Phone = "1234567",
                DateOfBirth = DateTime.Today,
                Year = 8
            });
        }

        private static void SeedGradeData(StudentService studentService)
        {
            var grades = new List<Grade>
                {
                    new Grade{Value= 1},
                    new Grade{Value= 1},
                    new Grade{Value= 2},
                    new Grade{Value= 4},
                    new Grade{Value= 4}
                };

            grades.ForEach(async g => await studentService.AddGrade(1, g));
        }
    }
}
