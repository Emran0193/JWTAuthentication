using JWTAuthentication.Core.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAuthentication.Services.Services.Interface
{
    public interface IService
    {
        Task<UserDTO> GetUserDetails(LoginDTO loginDTO);
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<bool> UserExists(string username);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetUser(int id);
    }
}
