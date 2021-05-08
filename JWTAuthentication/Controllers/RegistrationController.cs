using AutoMapper;
using JWTAuthentication.Core.Models.Dtos;
using JWTAuthentication.Models;
using JWTAuthentication.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IService _service;
        private readonly IMapper _mapper;
        public RegistrationController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] User user)
        {
            try
            {
                var result = await _service.CreateUser(_mapper.Map<UserDTO>(user));
                return Ok(_mapper.Map<UserResponse>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UserUpdate([FromBody] User user, [FromQuery] int UserId)
        {
            try
            {
                var result = await _service.UpdateUser(_mapper.Map<UserDTO>(user));
                return Ok(_mapper.Map<UserResponse>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
