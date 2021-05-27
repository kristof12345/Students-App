using System.ComponentModel.DataAnnotations;

namespace Students.Database.Entities
{
    public class Grade
    {
        [Key]
        public long Id { get; set; }

        public int Value { get; set; }

        public Student Student { get; set; }
    }
}
