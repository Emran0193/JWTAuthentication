using JWTAuthentication.Core.Models.Dtos;

namespace JWTAuthentication.Services.Services.Interface
{
    public interface ITokenService
    {
        string Create(UserDTO user);
    }
}
