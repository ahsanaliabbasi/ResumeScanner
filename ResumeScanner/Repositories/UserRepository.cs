using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeScanner.Data;
using ResumeScanner.DTOs;
using ResumeScanner.Models;
using ResumeScanner.Services;

namespace ResumeScanner.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ResumeScannerDBContext _context;
        public readonly IMapper _mapper;
        public readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;
        public readonly IServices _services;


        public UserRepository(ResumeScannerDBContext context, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager, IServices services)
        {
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _services = services;
        }

        public async Task<SignUpResponseDTO> UserSignUp(SignupDTO signup)
        {


            var usernameCheck = await _context.Users.FirstOrDefaultAsync(u => u.UserName == signup.userName || u.Email==signup.email);
            if (usernameCheck != null)
            {
               return null;
            }


            var user= _mapper.Map<User>(signup);

            //var result = await _context.Users.AddAsync(user);

            // Creating User for Identity User
             var result= await _userManager.CreateAsync(user,signup.password);

            var userProfile = new UserProfile
            {
                userId = user.Id,
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

            var userResponse = _mapper.Map<SignUpResponseDTO>(signup);

            return userResponse;
        }

        public async Task<List<SignUpResponseDTO>> GetAllUsers()
        {
            var listofusers = await _context.Users.ToListAsync();
            List<SignUpResponseDTO> users = new List<SignUpResponseDTO>();

            foreach (var user in listofusers)
            {
                var userResponse= _mapper.Map<SignUpResponseDTO>(user);
                users.Add(userResponse);
            }
            return users;
        }

        public async Task<LoginResponseDTO> UserLogin(LoginDTO loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.userName, loginModel.password, isPersistent: false, lockoutOnFailure: false);
            if(result.Succeeded)
            {

                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginModel.userName);
                var loggedInUser = _mapper.Map<LoginResponseDTO>(user);
                var token = _services.Generate_JWT_Token(user);
                loggedInUser.token= token;
                return loggedInUser;
            }
            return null;
        }
    }
}
