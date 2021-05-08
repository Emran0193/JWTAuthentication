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
    public class LoginController : ControllerBase
    {
        private readonly IService _service;
        private readonly IMapper _mapper;
        public LoginController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Use to verify login use.
        /// </summary>
        /// <param name="userLoginDetails">Entered Value</param>
        /// <returns>true/false</returns>
        [HttpGet]//("{Email}/{Password}")]
        public async Task<IActionResult> Login([FromQuery] UserLoginDetails userLoginDetails)
        {
            bool result = await _service.VerifyUserDetails(_mapper.Map<UserLoginDetailsDTO>(userLoginDetails));
            if (result)
            {
                return Ok(new { UserId=result });
            }
            else
                return BadRequest(result);
        }
    }
}
