using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeScanner.Data;
using ResumeScanner.DTOs;
using ResumeScanner.Models;

namespace ResumeScanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ResumeScannerDBContext _context;
        public UserController(ResumeScannerDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task <IActionResult> GetAllUsers()
        {
            var users= await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignupDTO signup)
        {
            var user = new User
            {
                firstName = signup.firstName,
                lastName = signup.lastName,
                Email = signup.email,
                UserName = signup.userName,
                EmailConfirmed=true
            };


            var result= await _context.Users.AddAsync(user);

            var userProfile = new UserProfile
            {
                userId = result.Entity.Id,
                address = "Default",
                jobTitle = "Default",
                yearsOfExperience = 0,
                nameOfCurrentCompany = "Default",
                universityName = "Default",
                graduationYear = 1950,
                mastersDegreeStatus = 0,
                phdDegreeStatus = 0
            };

            var added = await _context.UserProfile.AddAsync(userProfile);
            await _context.SaveChangesAsync();

            // It is always recomended to return responses as DTO's to avoid serializable issues.
            // Here if we do not do this it wont let us to return a response.

            var userProfileCreated = new SignupDTO
            {
                userName=user.UserName,
                email=user.Email,   
                firstName=user.firstName,
                lastName=user.lastName,
                jobTitle=userProfile.jobTitle,
                mastersDegreeStatus=userProfile.mastersDegreeStatus,
                phdDegreeStatus=userProfile.phdDegreeStatus,
                address=userProfile.address,
                universityName=userProfile.universityName,
                graduationYear=userProfile.graduationYear,
                nameOfCurrentCompany=userProfile.nameOfCurrentCompany,
                yearsOfExperience=userProfile.yearsOfExperience
            };


            return Ok(userProfileCreated);
        }


    }
}
