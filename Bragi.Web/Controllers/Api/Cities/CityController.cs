using Bragi.BussinessLayer.Interfaces.Cities;
using Bragi.DataLayer.Models.Cities;
using Bragi.DataLayer.ViewModels.Cities;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.Cities
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class CityController : ReadableController<ICitiesService, City, CityViewModel>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICitiesService _service;
        public CityController(ICitiesService service, IMemoryCache memoryCache) : base(service)
        {
            _memoryCache = memoryCache;
            _service = service;
        }

        [HttpGet]
        public override async Task<IActionResult> GetList()
        {
            IEnumerable<CityViewModel> cities;
            if (_memoryCache.TryGetValue("Cities", out cities))
            {
                return Ok(cities.OrderBy(x => x.Name));
            }
            return Ok((await _service.GetAll()).OrderBy(x => x.Name));
        }

        [HttpGet("GetByIso2/{iso2Code}")]
        public async Task<IActionResult> GetByIso2(string iso2Code)
        {
            //IEnumerable<CityViewModel> cities;
            //if (_memoryCache.TryGetValue("Cities", out cities))
            //{
            //    return Ok(cities.Where(x => x.Iso2CountryCode == iso2Code.ToUpper()).ToList().OrderBy(x => x.Name));
            //}
            //return Ok((await _service.GetAll()).OrderBy(x => x.Name).Where(x => x.Iso2CountryCode == iso2Code));

            return Ok(await _service.GetByIso2(iso2Code));
        }


        [HttpGet("GetByName/{iso2Code}/{name}")]
        public async Task<IActionResult> GetByName(string iso2Code, string name)
        {
            return Ok(await _service.GetByCityName(iso2Code, name));
        }

    }
}
