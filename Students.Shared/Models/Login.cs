using System.ComponentModel.DataAnnotations;

namespace Students.Shared
{
    public class Login
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
