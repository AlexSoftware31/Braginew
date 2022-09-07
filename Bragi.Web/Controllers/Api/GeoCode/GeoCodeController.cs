using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.GeoCode
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class GeoCodeController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly IMunicipalityService _municipalityService;
        private readonly ISectorsService _sectorsService;
        private readonly IMemoryCache _memoryCache;

        public GeoCodeController(IProvinceService provinceService, ISectorsService sectorsService, IMunicipalityService municipalityService, IMemoryCache memoryCache)
        {
            _provinceService = provinceService;
            _municipalityService = municipalityService;
            _sectorsService = sectorsService;
            _memoryCache = memoryCache;
        }

        [HttpGet("GetProvinces")]
        public async Task<IActionResult> GetProvinces()
        {
            IEnumerable<ProvincesViewModel> provinces;
            if (_memoryCache.TryGetValue("Provinces", out provinces))
            {
                return Ok(provinces.OrderBy(x => x.ToponomyName));
            }
            return Ok((await _provinceService.GetAll()).OrderBy(x => x.ToponomyName));
        }

        [HttpGet("GetMunicipalities/{provinceCode}")]
        public async Task<IActionResult> GetMunicipalities(string provinceCode)
        {
            IEnumerable<MunicipalityViewModel> municipality;
            if (_memoryCache.TryGetValue("Municipalities", out municipality))
            {
                return Ok(municipality.Where(x => x.Province == provinceCode).OrderBy(x => x.ToponomyName));
            }
            var mun = await _municipalityService.GetAllMunicipalitiesByProvinceCode(provinceCode);
            if (mun != null) return Ok(mun.OrderBy(x => x.ToponomyName));
            return NoContent();
        }

        [HttpGet("GetSectors/{provinceCode}/{municipCode}")]
        public async Task<IActionResult> GetSectors(string provinceCode, string municipCode)
        {

            if (string.IsNullOrEmpty(provinceCode) || string.IsNullOrEmpty(municipCode)) return BadRequest($"You Must send the {nameof(provinceCode)} and {nameof(municipCode)}");
            IEnumerable<SectorsViewModel> sectors;
            if (_memoryCache.TryGetValue("Sectors", out sectors))
            {
                return Ok(sectors.Where(x => x.Province == provinceCode && x.Municipalities == municipCode).OrderBy(x => x.ToponomyName));
            }
            var sec = await _sectorsService.GetAllSectors(provinceCode, municipCode);
            if (sec != null) return Ok(sec.OrderBy(x => x.ToponomyName));
            return NoContent();
        }

        [HttpGet("GetGeoLocation/{geoCode}")]
        public async Task<IActionResult> GetGeoLocation(string geoCode)
        {

            if (string.IsNullOrEmpty(geoCode)) return BadRequest($"You must send the {nameof(geoCode)}");
            var geo = await _sectorsService.GetCodes(geoCode);
            return Ok(geo);
        }
    }
}
