using System.Text.Json;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.Countries;
using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.DataLayer;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Bragi.Web.Controllers
{
    public class PublicHealthsController : MvcCoreController
    {

        private readonly IPublicHealthService _publicHealthService;
        private readonly IApplicationTokenService _appToken;
        private readonly IMigratoryInfoService _migratoryInfoService;
        private readonly ICountriesService _countriesService;
        private readonly IEticketsService _eticketsService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IGenericInformationService _genericInformation;
        private readonly IApplicationsService _applicationsService;

        public PublicHealthsController(
            IPublicHealthService publicHealthService
            , IApplicationTokenService appToken
            , IMigratoryInfoService migratoryInfoService
            , ICountriesService countriesService
            , IEticketsService eticketsService
            , IStringLocalizer<SharedResource> localizer
            , IGenericInformationService genericInfomartion
            , IApplicationsService applicationsService
        )
        {
            _publicHealthService = publicHealthService;
            _appToken = appToken;
            _migratoryInfoService = migratoryInfoService;
            _countriesService = countriesService;
            _eticketsService = eticketsService;
            _localizer = localizer;
            _genericInformation = genericInfomartion;
            _applicationsService = applicationsService;
        }

        public async Task<IActionResult> Index(string token)
        {
            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);
            var isIssued = await CheckEmission(_applicationsService, token, null);
            if (isIssued) return RedirectToAction("TicketEmision", "TravelTicket", new { token = token });

            var app = await _appToken.GetByToken(token);
            ViewBag.ApplicationId = app.Payload.ApplicationId;
            ViewBag.Token = token;
            ViewBag.Countries = await _countriesService.GetAll();
            ViewBag.Language = lang.ToString();
            ViewBag.Code = app.Payload.Application.Code;
            var gi = await _genericInformation.GetByApplicationId(app.Payload.ApplicationId);
            var result = await _migratoryInfoService.GetByApplicationIdAndPublicHealth(app.Payload.ApplicationId);
            result.Payload.PersonIndex = 1;
            result.Payload.PreviousIndex = 0;
            result.Payload.GenericInformation = gi.Payload;
            return View(result.Payload);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PublicHealthViewModel phViewModel)
        {

            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);


            var app = await _appToken.GetByToken(phViewModel.Token);
            phViewModel.QuestionResponse = null;
            var result = await _publicHealthService.EditAsync(phViewModel);

            var isReadyToEmission =
                await _publicHealthService.IsReadyToEticketEmission(phViewModel.ApplicationId, phViewModel.PersonIndex);
            if (result.IsSuccessfulWithNoErrors)
            {
                if (isReadyToEmission.Payload)
                {
                    var insert = await _eticketsService.PrepareAndCreate(phViewModel.ApplicationId);
                    if (insert.IsSuccessfulWithNoErrors)
                    {
                        await _applicationsService.UpdateStatus(phViewModel.ApplicationId, StatusEnum.Completed);
                    }
                    await _eticketsService.SavePassengersIntoImi(phViewModel.ApplicationId);
                    return RedirectToAction("TicketEmision", "TravelTicket", new { token = phViewModel.Token });
                }

                ViewBag.ApplicationId = app.Payload.ApplicationId;
                ViewBag.Token = phViewModel.Token;
                ViewBag.Countries = await _countriesService.GetAll();
                ViewBag.Language = lang.ToString();
                var miResult = await _migratoryInfoService.GetByApplicationIdAndPublicHealth(app.Payload.ApplicationId);
                var gi = await _genericInformation.GetByApplicationId(app.Payload.ApplicationId);
                var shouldShowNotification = miResult.Payload.TotalCreated.Equals(phViewModel.PersonIndex);
                if (shouldShowNotification)
                    ShowNotification(_localizer["Notice"], _localizer["Val.MustFillAllApplications"], "warning");

                var shouldIndexChange = miResult.Payload.TotalCreated >= phViewModel.PersonIndex + 1;
                miResult.Payload.PersonIndex = shouldIndexChange ? phViewModel.PersonIndex + 1 : phViewModel.PersonIndex;
                miResult.Payload.PreviousIndex = shouldIndexChange ? phViewModel.PersonIndex : phViewModel.PersonIndex - 1;
                miResult.Payload.GenericInformation = gi.Payload;
                ModelState.Clear();

                return View("Index", miResult.Payload);
            }

            ViewBag.ApplicationId = phViewModel.ApplicationId;
            ViewBag.Token = phViewModel.Token;
            ViewBag.Countries = await _countriesService.GetAll();
            ViewBag.Language = lang.ToString();
            var miResult2 = await _migratoryInfoService.GetByApplicationIdAndPublicHealth(phViewModel.ApplicationId);
            var gi2 = await _genericInformation.GetByApplicationId(phViewModel.ApplicationId);
            miResult2.Payload.PersonIndex = phViewModel.PersonIndex + 1;
            miResult2.Payload.PreviousIndex = phViewModel.PersonIndex;
            miResult2.Payload.GenericInformation = gi2.Payload;
            var infolist = miResult2.Payload.MigratoryInformation;
            infolist[
                    infolist.FindIndex(x =>
                        x.CustomsInformation.MigratoryInformationId.Equals(phViewModel.MigratoryInformationId))]
                .PublicHealth = phViewModel;

            return View("Index", miResult2.Payload);
        }
    }
}
