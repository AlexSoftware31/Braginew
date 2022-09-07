using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NetCoreUtilities.Extensions;

namespace Bragi.Web.Controllers.Api.Applications
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class ApplicationController : CoreController<IApplicationsService,Application,ApplicationViewModel>
    {
        private readonly IApplicationsService  _applicationService;

        public ApplicationController(IApplicationsService  applicationService) : base(applicationService)
        {
            _applicationService = applicationService;
        }

        //[HttpPost]
        //public async Task<IActionResult> RequestApplication(AuthViewModel auth)
        //{
        //    var opResult = await _applicationService.CreateApplication(auth);
            
        //    if(opResult.IsSuccessfulWithNoErrors){
        //        return Ok(opResult.Payload);
        //    }
        //    return BadRequest(opResult);
        //}

        //[HttpPut("UpdateStep")]
        //public async Task<IActionResult> UpdateStep(UpdateStepViewModel update)
        //{
        //    var result = await _applicationService.UpdateStep(update);
        //    if (result.IsSuccessfulWithNoErrors) return Ok(result.Payload);
        //    return BadRequest(result);
        //}

        [HttpPut("AcceptTerms/{applicationId}")]
        public async Task<IActionResult> AcceptTerms(int applicationId)
        {
            var result = await _applicationService.UpdateTermsAndConditions(applicationId);
            if (result.IsSuccessfulWithNoErrors) return Ok(result.Payload);
            return BadRequest(result.GetMessageErrorBody());
        }


        [HttpPut("AssistedInfo")]
        public async Task<IActionResult> AssistedInfo(AssistantViewModel assistant)
        {
            var result = await _applicationService.SetAssistant(assistant);
            if (result.IsSuccessfulWithNoErrors) return Ok(result.Succeeded);
            return BadRequest(result.GetMessageErrorBody());
        }
    }
}