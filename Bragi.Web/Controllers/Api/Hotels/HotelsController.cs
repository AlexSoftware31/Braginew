using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Hotels;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.ViewModels.Hotels;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Bragi.Web.Controllers.Api.Hotels
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class HotelsController : ReadableController<IHotelService,Hotel,HotelViewModel>
    {
        private readonly IHotelService _service;
        private readonly IMemoryCache _memoryCache;
        public HotelsController(IHotelService service, IMemoryCache memoryCache) : base(service)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public override async Task<IActionResult> GetList()
        {
            IEnumerable<HotelViewModel> hotels;
            if (_memoryCache.TryGetValue("Hotels", out hotels))
            {
                return Ok(hotels.OrderBy(x => x.Name));
            }
            return Ok((await _service.GetAll()).OrderBy(x => x.Name));
        } 
    }
}
