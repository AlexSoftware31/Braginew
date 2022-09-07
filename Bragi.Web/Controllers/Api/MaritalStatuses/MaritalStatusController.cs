using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.DataLayer.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.MaritalStatuses
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMaritalStatusService _service;
        public MaritalStatusController(IMaritalStatusService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);
            var requestResult = await _service.GetMultilanguage(lang);
            if (requestResult.IsSuccessfulWithNoErrors) return Ok(requestResult.Payload.OrderBy(x=>$"{culture}"));
            return NoContent();
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
