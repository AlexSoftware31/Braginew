using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Airlines;
using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.ViewModels.Airlines;
using Bragi.DataLayer.ViewModels.Hotels;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Bragi.Web.Controllers.Api.Airlines
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class AirlineController : ReadableController<IAirlineService, Airline, AirlineViewModel>
    {
        private readonly IAirlineService _service;
        private readonly IMemoryCache _memoryCache;
        public AirlineController(IAirlineService service, IMemoryCache memoryCache) : base(service)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public override async Task<IActionResult> GetList()
        {
            IEnumerable<AirlineViewModel> airlines;

            if (_memoryCache.TryGetValue("Airlines", out airlines))
            {
                return Ok(airlines.OrderBy(x => x.Name));
            }
            return Ok((await _service.GetAll()).OrderBy(x => x.Name));

        }
    }
}
