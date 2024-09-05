using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeScanner.Data;
using ResumeScanner.DTOs;
using ResumeScanner.Models;
using ResumeScanner.Repositories;

namespace ResumeScanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ResumeScannerDBContext _context;
        public readonly IUserRepository _userRepository;


        public UserController(ResumeScannerDBContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;

        }


        [HttpGet("GetAllUsers")]
        public async Task <ActionResult<List<SignUpResponseDTO>>> GetAllUsers()
        {
            var users= await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody]SignupDTO signup)
        {
            var userProfileCreated = await _userRepository.UserSignUp(signup);

            return Ok(userProfileCreated);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var user = await _userRepository.UserLogin(login);

            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(new { Message="User not Found!"});
        }

    }
}
