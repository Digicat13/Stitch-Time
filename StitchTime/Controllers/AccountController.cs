using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost ("SignUp")]
        public async Task<ActionResult<UserLoginDto>> SignUp(UserDto dto)
        {
            try
            {
                var result = await _accountService.SignUp(dto);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
}

        [HttpPost("SignIn")]
        public async Task<ActionResult<UserDto>> SignIn(UserDto dto)
        {
            try
            {
                var result = await _accountService.SignIn(dto);
                return Ok(result);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("Logout/{id}")]
        public async Task<ActionResult> Logout(string id)
        {
            try
            {
                var Id = id;
                await _accountService.Logout(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
