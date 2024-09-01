using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.Models
{
    public class UserProfile
    {
        [Required]
        public string jobTitle { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Years of experience cannot be less than 0.")]
        [Required]
        public int yearsOfExperience { get; set; }
        [Required]
        public string nameOfCurrentCompany { get; set; }
        [Required]
        [Range(1950,int.MaxValue, ErrorMessage ="Graduation Year can not be before 1950")]
        public int graduationYear { get; set; }
        [Required]
        public string universityName { get; set;}
        [Required]
        public int mastersDegreeStatus { get; set; }
        [Required]
        public int phdDegreeStatus { get; set; }
        [Required]
        public string address { get; set; }
    }
}
