using Bragi.BussinessLayer.Interfaces.Ports;
using Bragi.DataLayer.Models.Ports;
using Bragi.DataLayer.ViewModels.Ports;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Bragi.Web.Controllers.Api.Ports
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class PortController : ReadableController<IPortsService, Port, PortViewModel>
    {
        private readonly IPortsService _portsService;
        private readonly IMemoryCache _memoryCache;
        public PortController(IPortsService service, IMemoryCache memoryCache) : base(service)
        {
            _portsService = service;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public override async Task<IActionResult> GetList()
        {
            IEnumerable<PortViewModel> ports;
            if (!_memoryCache.TryGetValue("Ports", out ports))
            {
                _memoryCache.Set("Ports", await _portsService.GetAll());
            }
            ports = _memoryCache.Get<List<PortViewModel>>("Ports");
            return Ok(ports);
        }

        [HttpGet("GetByTransportation/{transpMethodId?}")]
        public async Task<IActionResult> Get(int transpMethodId = 3)
        {
            var result = await _portsService.GetAll(transpMethodId);
            return Ok(result.Payload);
        }

        [HttpGet("GetAllDomPorts/{transpMethodId}/{name?}")]
        public async Task<IActionResult> GetDomPorts(int transpMethodId, string name)
        {
            var result = await _portsService.GetAllDominicanPorts(transpMethodId,name);
            return Ok(result.Payload);
        }


        [HttpGet("GetbyName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            IEnumerable<PortViewModel> ports;
            if (!_memoryCache.TryGetValue("Ports", out ports))
            {
                _memoryCache.Set("Ports", await _portsService.GetAll());
            }
            ports = _memoryCache.Get<IEnumerable<PortViewModel>>("Ports");
            return Ok(ports.Where(x => EF.Functions.Like(x.Name, $"%{name}%")).ToList());
        }
    }
}