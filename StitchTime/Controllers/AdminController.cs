using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using System;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        [HttpPost]

        public ActionResult CreateRole(RoleDto roleDto)
        {
            try
            {
                _adminService.CreateRole(roleDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
