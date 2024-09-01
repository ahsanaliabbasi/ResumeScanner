using ResumeScanner.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.Models
{
    public class UserSkills
    {
        public int skillId { get; set; }
        [Required]
        public string skillName { get; set; }

        [domainValidation("Databases", "Data Science","Softwaren Development", "Q/A & Testing")]
        [Required]
        public string majorDomain { get; set; }


    }
}
