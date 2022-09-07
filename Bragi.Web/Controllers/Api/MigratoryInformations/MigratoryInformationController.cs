using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.MigratoryInformations
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class MigratoryInformationController : CoreController<IMigratoryInfoService,MigratoryInformation,MigratoryInformationViewModel>
    {

        private readonly IMigratoryInfoService _service;

        public MigratoryInformationController(IMigratoryInfoService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetByApplicationId/{applicationId}")]
        public async Task<IActionResult> GetByApplicationId(int applicationId)
        {
            var reqResult = await _service.GetInformationByApplicationId(applicationId);
            if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
            return NoContent();
        }

        //[HttpPost("DispatchCreation")]
        //public async Task<IActionResult> DispatchCreation(MigratoryInformation entity)
        //{
        //    entity.Nationality = entity.Nationality.ToUpper();
        //    var reqResult = await _service.DispatchCreation(entity);
        //    if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
        //    return BadRequest(reqResult.GetMessageErrorBody());
        //}

        //[HttpPut("DispatchUpdate")]
        //public async Task<IActionResult> DispatchUpdate(MigratoryInformation entity)
        //{
        //    var reqResult = await _service.DispatchUpdate(entity);
        //    if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
        //    return BadRequest(reqResult.GetMessageErrorBody());
        //}

        [HttpGet("GetInfoToCustoms/{applicationId}")]
        public async Task<IActionResult> GetInfoToCustoms(int applicationId)
        {
            var reqResult = await _service.GetByApplicationIdAndCustoms(applicationId);
            if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
            return NoContent();
        }

        [HttpGet("GetInfoToPublicHealth/{applicationId}")]
        public async Task<IActionResult> GetInfoToPublicHealth(int applicationId)
        {
            var reqResult = await _service.GetByApplicationIdAndPublicHealth(applicationId);
            if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
            return NoContent();
        }
    }
}
