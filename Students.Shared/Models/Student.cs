using System;
using System.ComponentModel.DataAnnotations;

namespace Students.Shared
{
    public class Student
    {
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
