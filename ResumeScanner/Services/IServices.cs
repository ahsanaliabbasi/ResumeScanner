using ResumeScanner.DTOs;
using ResumeScanner.Models;

namespace ResumeScanner.Services
{
    public interface IServices
    {
        string Generate_JWT_Token(User user);
    }
}
