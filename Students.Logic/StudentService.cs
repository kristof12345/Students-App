using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Students.Database.Entities;
using Students.Logic.Models;

namespace Students.Logic
{
    public class StudentService
    {
        private readonly DatabaseContext Context;

        public StudentService(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Student>> ListStudents()
        {
            return await Context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Statictic>> ListStatistics()
        {
            return await Context.Students.AsNoTracking().Include(s => s.Grades).Where(s => s.Grades.Count > 0).Select(
                s => new Statictic
                {
                    Name = s.Name,
                    Average = s.Grades.Average(g => g.Value),
                    BestGrade = s.Grades.Max(g => g.Value),
                    NumberOfOneGrades = s.Grades.Count(g => g.Value == 1)
                }
            ).OrderByDescending(s => s.Average).ToListAsync();
        }

        public async Task AddStudent(Student student)
        {
            await Context.Students.AddAsync(student);
            await Context.SaveChangesAsync();
        }

        public async Task AddGrade(long id, Grade grade)
        {
            var user = await Context.Students.Include(u => u.Grades).FirstOrDefaultAsync(s => s.Id == id);
            if (user != null)
            {
                user.Grades.Add(grade);
                await Context.SaveChangesAsync();
            }
        }
    }
}
