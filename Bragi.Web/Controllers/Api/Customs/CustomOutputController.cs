using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Applications;

namespace Bragi.Web.Controllers.Api.Customs
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class CustomOutputController : ControllerBase
    {
        private readonly ICustomsService _customsService;
        private readonly IApplicationsService _appservice;


        public CustomOutputController(ICustomsService customsService,IApplicationsService appservice)
        {
            _customsService = customsService;
            _appservice = appservice;
        }


        [HttpPost("prepareOutputData"), Authorize(Roles = "Poster")]
        public async Task<IActionResult> PrepareOutputData(OutputParams outputParams)
        {
            //var m = await _customsService.SendInformationToCustomsWs(outputParams);
            var m = await _customsService.SendInformationToCustomsWs(outputParams);
            return Ok(m);
        }

    }
}