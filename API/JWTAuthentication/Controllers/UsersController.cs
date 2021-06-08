using AutoMapper;
using JWTAuthentication.Models;
using JWTAuthentication.Services.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IService _service;
        private readonly IMapper _mapper;
        public UsersController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_mapper.Map<List<UserResponse>>(await _service.GetAll()));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(_mapper.Map<UserResponse>(await _service.GetUser(id)));
        }
    }
}
