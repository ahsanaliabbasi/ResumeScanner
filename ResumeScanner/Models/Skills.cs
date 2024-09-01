using ResumeScanner.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.Models
{
    public class Skills
    {
        [Key]
        public int skillId { get; set; }
        [Required]
        public string skillName { get; set; }

        [domainValidation("Databases", "Data Science","Softwaren Development", "Q/A & Testing")]
        [Required]
        public string majorDomain { get; set; }

        public List<User> Users { get; set; }

    }
}
