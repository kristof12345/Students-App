using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Students.Database.Entities
{
    public class Student
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
