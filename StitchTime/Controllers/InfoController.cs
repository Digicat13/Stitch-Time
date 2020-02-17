using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]

    public class InfoController : ControllerBase
    {
        
    }
}
