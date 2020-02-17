using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;

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
        public ActionResult<InfoByUserDto> GetInfo()
        {
            try
            {
                var result = _userService.GetInfoById(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetPmProjectsInfo")]
        public ActionResult<PmProjectsInfoDto> GetPmProjectsInfo()
        {
            try
            {
                var result = _userService.GetPmProjectsInfo(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetPmReportsInfo")]
        public ActionResult<PmReportsInfoDto> GetPmReportsInfo()
        {
            try
            {
                var result = _userService.GetPmReportsInfo(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}