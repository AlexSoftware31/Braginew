using Bragi.BussinessLayer.Interfaces.FlightMotives;
using Bragi.DataLayer.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreUtilities.Extensions;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.FlightMotives
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class FlightMotivesController : ControllerBase 
    {
        private readonly IFlightMotivesService _service;

        public FlightMotivesController(IFlightMotivesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);
            var requestResult = await _service.GetMultilanguage(lang);
            if (requestResult.IsSuccessfulWithNoErrors) return Ok(requestResult.Payload);
            return BadRequest(requestResult.GetMessageErrorBody());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var reqResult = await _service.GetByIdAsync(id);
            if (reqResult != null) return Ok(reqResult);
            return NoContent();
        }

    }
}
