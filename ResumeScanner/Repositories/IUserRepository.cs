using Microsoft.AspNetCore.Mvc;
using ResumeScanner.DTOs;

namespace ResumeScanner.Repositories
{
    public interface IUserRepository
    {
        public  Task<SignUpResponseDTO> UserSignUp(SignupDTO signup);

        public Task<List<SignUpResponseDTO>> GetAllUsers();

        public Task<LoginResponseDTO> UserLogin(LoginDTO loginModel);
    }
}
