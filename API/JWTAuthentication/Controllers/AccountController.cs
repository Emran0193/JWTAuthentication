using AutoMapper;
using JWTAuthentication.Core.Models.Dtos;
using JWTAuthentication.Models;
using JWTAuthentication.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IService _service;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AccountController(IService service, IMapper mapper, ITokenService tokeService)
        {
            _service = service;
            _mapper = mapper;
            _tokenService = tokeService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register register)
        {
            try
            {
                if (await _service.UserExists(register.UserName))
                    return BadRequest("Username is taken!!!");

                using var hmac = new HMACSHA512();

                var user = new AppUser
                {
                    UserName = register.UserName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                    PasswordSalt = hmac.Key
                };

                var result = await _service.CreateUser(_mapper.Map<UserDTO>(user));

                return Ok(new UserResponse { UserName = user.UserName, Token = _tokenService.Create(result) });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            var user = await _service.GetUserDetails(_mapper.Map<LoginDTO>(login));

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return Ok(new UserResponse { UserName = user.UserName, Token = _tokenService.Create(user) });
        }
    }
}
