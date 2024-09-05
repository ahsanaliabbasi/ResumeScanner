using AutoMapper;
using ResumeScanner.DTOs;
using ResumeScanner.Models;

namespace ResumeScanner.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SignupDTO, SignUpResponseDTO>().ReverseMap();
            CreateMap<SignupDTO,User>().ReverseMap();
            CreateMap<SignUpResponseDTO, User>().ReverseMap();
            CreateMap<LoginResponseDTO,User>().ReverseMap();    
        }
    }
}
