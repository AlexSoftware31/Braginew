using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.PublicHealths
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class PublicHealthController : CoreController<IPublicHealthService,PublicHealth,PublicHealthViewModel>
    {

        private readonly IPublicHealthService _service;
        public PublicHealthController(IPublicHealthService service) : base(service)
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
    }
}
