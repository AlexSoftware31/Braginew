using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.ViewModels.Auth;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using Bragi.DataLayer;
using Microsoft.Extensions.Localization;

namespace Bragi.Web.Controllers
{
    public class AuthController : MvcCoreController
    {
        private readonly IApplicationsService _applicationService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AuthController(IApplicationsService applicationService, IStringLocalizer<SharedResource> localizer)
        {

            _applicationService = applicationService;
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult TravelLogin(bool hasError = false)
        {

            var viewModel = new AuthViewModel
            {
                HasErrors = hasError
            };
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> RequestTravel(AuthViewModel auth)
        {
            var opResult = await _applicationService.CreateApplication(auth);

            if (opResult.IsSuccessfulWithNoErrors)
            {
                return RedirectToAction("StepOne", "TravelTicket", new { token = opResult.Payload.ApplicationToken.Token });
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> TravelLogin(AuthViewModel auth)
        {
            var token = RandomGeneration.ApplicationMd5Gen(auth);
            var infodDidExist = await _applicationService.IsEticketEmited(token, null);
            if (infodDidExist.Payload)
            {
                return RedirectToAction("TicketEmision", "TravelTicket", new { token = token });
            }
            ShowNotification(_localizer["Notice"],_localizer["InvalidAppCode"],"info");
            return View();
        }



        [HttpGet]
        public IActionResult TravelRegister(bool hasError = false)
        {
            var viewModel = new AuthViewModel
            {
                HasErrors = hasError
            };
            return View(viewModel);
        }

    }
}