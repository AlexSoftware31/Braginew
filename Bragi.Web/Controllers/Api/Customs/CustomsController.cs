using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.Customs
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class CustomsController : CoreController<ICustomsService,CustomsInformation,CustomsInformationWiewModel>
    {
        private readonly ICustomsService _service;
        public CustomsController(ICustomsService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetByApplicationId/{applicationId}")]
        public async Task<IActionResult> GetByApplicationId(int applicationId)
        {
            var reqResult = await _service.GetByApplicationId(applicationId);
            if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
            return NoContent();
        }

        //[HttpPut]
        //public override async Task<IActionResult> Edit(CustomsInformation entity)
        //{
        //    var reqResult =await _service.UpdateWithConditions(entity);
        //    if (reqResult.IsSuccessfulWithNoErrors) return Ok(reqResult.Payload);
        //    return BadRequest(reqResult.GetMessageErrorBody());
        //}
    }
}
