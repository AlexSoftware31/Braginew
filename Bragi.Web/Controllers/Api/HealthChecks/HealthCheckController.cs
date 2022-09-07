using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Api.HealthChecks
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(true);
        }
    }
}