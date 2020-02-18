using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StitchTime.Core.Dto;
using StitchTime.Core.Errors;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class ErrorController
    {
        //private readonly ILogger<ErrorController> logger;
        //public ErrorController(ILogger<ErrorController> logger)
        //{
        //    this.logger = logger;
        //}
        //[Route("Error")]
        //[AllowAnonymous]
        //public ActionResult Error()
        //{
        //    var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        //    var errorInfo = new ErrorDto();
        //    errorInfo.Details = exceptionHandlerPathFeature.Error();

        //    logger.LogError($"The path {exceptionHandlerPathFeature.Path} " +
        //                    $"threw an exception {exceptionHandlerPathFeature.Error}");
        //    return null;

        //}
        
    }
}
