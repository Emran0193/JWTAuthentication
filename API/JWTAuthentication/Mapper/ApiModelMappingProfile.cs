using AutoMapper;
using JWTAuthentication.Core.Models.Dtos;
using JWTAuthentication.Models;

namespace JWTAuthentication.Mapper
{
    public class ApiModelMappingProfile : Profile
    {
        public ApiModelMappingProfile()
        {
            CreateMap<Login, LoginDTO>();
            CreateMap<AppUser, UserDTO>();
            CreateMap<UserDTO, UserResponse>();
        }
    }
}
