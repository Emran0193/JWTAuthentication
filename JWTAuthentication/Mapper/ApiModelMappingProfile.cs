using AutoMapper;
using JWTAuthentication.Core.Models.Dtos;
using JWTAuthentication.Models;

namespace JWTAuthentication.Mapper
{
    public class ApiModelMappingProfile : Profile
    {
        public ApiModelMappingProfile()
        {
            CreateMap<UserLoginDetails, UserLoginDetailsDTO>().ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, UserResponse>();
            //CreateMap<User, LoginDTO>().ForPath(dist => dist.UserName,opt => opt.MapFrom(src => src.Email))
                //.ForPath(dist => dist.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
