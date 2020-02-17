using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using System;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]

    public class InfoController : ControllerBase
    {
        private readonly IStartInfoService _startInfoService;
        public InfoController(IStartInfoService startInfoService)
        {
            _startInfoService = startInfoService;
        }


        [HttpGet]

        public ActionResult<IStartInfoService> GetStartInfo()
        {
            try
            {
                var result = _startInfoService.GetStartInfo();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
