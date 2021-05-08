using JWTAuthentication.Core.Models.Dtos;
using System.Threading.Tasks;

namespace JWTAuthentication.Services.Services.Interface
{
    public interface IService
    {
        Task<bool> VerifyUserDetails(UserLoginDetailsDTO userLoginDetailsDTO);
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
    }
}
