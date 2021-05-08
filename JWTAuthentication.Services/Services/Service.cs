using AutoMapper;
using JWTAuthentication.Core.Models.Dtos;
using JWTAuthentication.Persistance.Entities;
using JWTAuthentication.Persistance.Repository.IRepository;
using JWTAuthentication.Services.Services.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Services.Services
{
    public class Service : IService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public Service(ILoginRepository loginRepository, IMapper mapper, IUserRepository userRepository)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            var newUser = _mapper.Map<User>(userDTO);
            await _userRepository.CreateUser(newUser);
            return _mapper.Map<UserDTO>(newUser);
        }
        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var existingUser = _mapper.Map<User>(userDTO);
            await _userRepository.UpdateUser(existingUser);
            return _mapper.Map<UserDTO>(existingUser);
        }

        public async Task<bool> VerifyUserDetails(UserLoginDetailsDTO userLoginDetailsDTO)
        {
            var userDetails = await _loginRepository.GetAll();
            return userDetails.Any(x => x.Email == userLoginDetailsDTO.Email & x.Password == userLoginDetailsDTO.Password);
        }
    }
}
