using Bragi.BussinessLayer.Interfaces.Ocupations;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.Ocupations
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class OcupationsController : ControllerBase //ReadableController<IOcupationsService,Ocupation,OcupationViewModel>
    {
        private readonly IOcupationsService _service;
        public OcupationsController(IOcupationsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);
            var requestResult = await _service.GetMultilanguage(lang);
            if (requestResult.IsSuccessfulWithNoErrors)
            {
                var ordered = lang == LanguageEnum.Spanish
                    ? requestResult.Payload.OrderBy(x => x.Spanish)
                    : requestResult.Payload.OrderBy(x => x.English);
                return Ok(ordered);
            }
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