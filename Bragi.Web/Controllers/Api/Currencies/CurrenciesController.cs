using Bragi.BussinessLayer.Interfaces.Currencies;
using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.ViewModels.Currencies;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Bragi.Web.Controllers.Api.Currencies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class CurrenciesController :ReadableController<ICurrencyService,Currency,CurrencyViewModel>
    {
        private readonly ICurrencyService _service;
        public CurrenciesController(ICurrencyService service) : base(service)
        {
            _service = service;
        }
        [HttpGet]
        public override async Task<IActionResult> GetList()
            => Ok((await _service.GetAll()).OrderBy(x => x.Name));

    }
}
