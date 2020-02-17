using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using StitchTime.Core.Entities;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet("GetInfo")]
        public async Task<ActionResult<InfoByUserDto>> GetInfo()
        {
            try
            {
                var result = await _userService.GetInfoById(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetPmProjectsInfo")]
        public async Task<ActionResult<PmProjectsInfo>> GetPmProjectsInfo()
        {
            try
            {
                var result = await _userService.GetPmProjectsInfo(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}