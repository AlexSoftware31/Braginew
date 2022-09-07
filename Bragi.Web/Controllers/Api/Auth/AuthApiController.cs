using Bragi.BussinessLayer.Interfaces.Jwt;
using Bragi.DataLayer.ViewModels.Jwt;
using Microsoft.AspNetCore.Mvc;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {

        private readonly IJwtService _jwtService;

        public AuthApiController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(JwtAuth user)
        {
            var requestResult = RequestResult<JwtViewModel>.Failed();
            if (user != null)
            {
                requestResult = await _jwtService.CreateInternalJwt(user);
                if (requestResult.IsSuccessfulWithNoErrors)
                {
                    return Ok(requestResult.Payload.BearerToken);
                }
                return BadRequest(requestResult.Errors);
            }
            return BadRequest(requestResult.Errors);
        }
    }
}