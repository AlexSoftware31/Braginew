using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Countries;
using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.ViewModels.Countries;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Bragi.Web.Controllers.Api.Countries
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class CountriesController : ReadableController<ICountriesService,Country,CountryViewModel>
    {
        private readonly ICountriesService _service;
        private readonly IMemoryCache _memoryCache;
        public CountriesController(ICountriesService service, IMemoryCache memoryCache) : base(service)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public override async Task<IActionResult> GetList()
        {
            IEnumerable<CountryViewModel> countries;
            if (_memoryCache.TryGetValue("Countries", out countries))
            {
                return Ok(countries.OrderBy(x => x.Name));
            }
            return Ok((await _service.GetAll()).OrderBy(x => x.Name));
        }
    }
}
