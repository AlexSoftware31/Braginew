using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Api.Customs
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    [AllowAnonymous]
    public class DeclaredMerchController : CoreController<IDeclaredMerchService,DeclaredMerch,DeclaredMerchViewModel>
    {
        public DeclaredMerchController(IDeclaredMerchService service) : base(service)
        {
        }
    }
}
