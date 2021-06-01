using AutoMapper;
using JWTAuthentication.Core.Models.Dtos;
using JWTAuthentication.Persistance.Entities;

namespace JWTAuthentication.Services.Mapper
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, UserDTO>().ReverseMap();
        }
    }
}
