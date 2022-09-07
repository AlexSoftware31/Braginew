using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Api.PublicHealths
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    [AllowAnonymous]
    public class PublicHealthStopOverController : CoreController<IPublicHealthStopOverService, PublicHealthStopOver, PublicHealthStopOverViewModel>
    {
        public PublicHealthStopOverController(IPublicHealthStopOverService service) : base(service)
        {
        }
    }
}
