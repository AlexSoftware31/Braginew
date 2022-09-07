using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Api.PublicHealths
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    [AllowAnonymous]
    public class PublicHealthCountriesController : CoreController<IPublicHealthCountriesService, PublicHealthCountries, PublicHealthCountriesViewModel>
    {
        public PublicHealthCountriesController(IPublicHealthCountriesService service) : base(service)
        {
        }
    }
}
