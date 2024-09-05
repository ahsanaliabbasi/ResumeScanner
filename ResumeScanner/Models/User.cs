using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ResumeScanner.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }


        public List<Skills> Skills { get; set; }

        public UserProfile userProfile { get; set; }

    }
}
