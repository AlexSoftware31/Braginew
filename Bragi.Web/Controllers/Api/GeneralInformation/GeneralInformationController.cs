using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.GeneralInformation
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class GeneralInformationController : CoreController<IGenericInformationService, GenericInformation, GenericInformationViewModel>
    {
        private readonly IGenericInformationService _service;
        public GeneralInformationController(IGenericInformationService service) : base(service)
         => _service = service;

        [HttpGet("GetByApplicationId/{applicationId}")]
        public async Task<IActionResult> GetByApplicationId(int applicationId)
        {
            var result = await _service.GetByApplicationId(applicationId);
            if (result.IsSuccessfulWithNoErrors)
            {
                return Ok(result.Payload);
            }
            return NoContent();
        }
    }
}