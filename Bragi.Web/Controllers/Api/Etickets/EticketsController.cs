using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.DataLayer.Models.ETickets;
using Bragi.DataLayer.ViewModels.ETickets;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bragi.Web.Controllers.Api.Etickets
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer")]
    public class EticketsController : CoreController<IEticketsService,Eticket,EticketViewModel>
    {
        public EticketsController(IEticketsService service) : base(service)
        {
        }
    }
}
