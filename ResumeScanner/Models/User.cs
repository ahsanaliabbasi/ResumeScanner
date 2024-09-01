using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.Models
{
    public class User
    {
        public int userId { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email Address!")]
        [Required]
        public string email { get; set; }



    }
}
