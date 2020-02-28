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

        [HttpGet("GetInfo/{id}")]
        public ActionResult<InfoByUserDto> GetInfo(string id)
        {
            try
            {
                var result = _userService.GetInfoById(id);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetPmProjectsInfo/{id}")]
        public ActionResult<PmProjectsInfoDto> GetPmProjectsInfo(string id)
        {
            try
            {
                var result = _userService.GetPmProjectsInfo(id);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetPmReportsInfo/{id}")]
        public ActionResult<PmReportsInfoDto> GetPmReportsInfo(string id)
        {
            try
            {
                var result = _userService.GetPmReportsInfo(id);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("GetTeamLeadInfo/{id}")]
        public ActionResult<TeamLeadInfoDto> GetTeamLeadInfo(string id)
        {
            try
            {
                var result = _userService.GetTeamLeadInfo(id);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}