using Bragi.BussinessLayer.Interfaces.Airlines;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.Countries;
using Bragi.BussinessLayer.Interfaces.Currencies;
using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.BussinessLayer.Interfaces.FlightMotives;
using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.BussinessLayer.Interfaces.Hotels;
using Bragi.BussinessLayer.Interfaces.Jwt;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.Ocupations;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Interfaces.Ports;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.DataLayer;
using Bragi.DataLayer.Configuration.OptionsModel;
using Bragi.DataLayer.Enums;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.Validators.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.ETickets;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Bragi.DataLayer.ViewModels.TravelTicket;
using Bragi.Web.Controllers.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SelectPdf;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bragi.DataLayer.Validators.MigratoryInfo;
using FluentValidation.AspNetCore;
using NetCoreUtilities.Models;
using System.Text.Json;

namespace Bragi.Web.Controllers
{
    public class TravelTicketController : MvcCoreController
    {
        private readonly IApplicationsService _appService;
        private readonly IEticketsService _eticketsService;
        private readonly IApplicationTokenService _appToken;
        private readonly IOptions<GeneratePdfUrl> _pdfUrl;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _accessor;
        private readonly IGenericInformationService _genericInformation;
        private readonly IMigratoryInfoService _migratoryInfoService;
        private readonly IPortsService _portsService;
        private readonly ICountriesService _countriesService;
        private readonly IOcupationsService _ocupationsService;
        private readonly IProvinceService _provinceService;
        private readonly IMaritalStatusService _matStatusService;
        private readonly IAirlineService _airlineService;
        private readonly IFlightMotivesService _flightMotivesService;
        private readonly IHotelService _hotelService;
        private readonly ICustomsService _customsService;
        private readonly ICurrencyService _currencyService;
        private readonly IPublicHealthService _publicHealthService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public TravelTicketController(IApplicationsService appService
            , IEticketsService eticketsService
            , IApplicationTokenService appToken
            , IOptions<GeneratePdfUrl> pdfUrl
            , IJwtService jwtService
            , IHttpContextAccessor accessor
            , IGenericInformationService genericInformation
            , IMigratoryInfoService migratoryInfoService
            , IPortsService portsService
            , ICountriesService countriesService
            , IOcupationsService ocupationsService
            , IProvinceService provinceService
            , IMaritalStatusService maritalStatusService
            , IAirlineService airlineService
            , IFlightMotivesService flightMotivesService
            , IHotelService hotelService
            , ICustomsService customsService
            , ICurrencyService currencyService
            , IPublicHealthService publicHealthService
            , IStringLocalizer<SharedResource> localizer
        )
        {
            _appService = appService;
            _eticketsService = eticketsService;
            _appToken = appToken;
            _pdfUrl = pdfUrl;
            _jwtService = jwtService;
            _accessor = accessor;
            _genericInformation = genericInformation;
            _migratoryInfoService = migratoryInfoService;
            _portsService = portsService;
            _countriesService = countriesService;
            _ocupationsService = ocupationsService;
            _provinceService = provinceService;
            _matStatusService = maritalStatusService;
            _airlineService = airlineService;
            _flightMotivesService = flightMotivesService;
            _hotelService = hotelService;
            _customsService = customsService;
            _currencyService = currencyService;
            _publicHealthService = publicHealthService;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index(string token)
        {
            var info = await _appService.DidExistReturnInfo(token);
            if (info.IsSuccessfulWithNoErrors)
            {
                if (info.Payload.Step.StepsEnum == StepsEnum.Submitted) { return RedirectToAction(nameof(TicketEmision), new { Token = info.Payload.ApplicationToken.Token }); }

                var jwt = _jwtService.CreateJwt(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                var vm = new TravelticketViewModel
                {
                    Application = info.Payload,
                    JwtViewModel = jwt.Payload
                };
                return View(vm);
            }
            return View();
        }


        public async Task<IActionResult> StepOne(string token)
        {
            var isIssued = await CheckEmission(_appService, token, null);
            if (isIssued) return RedirectToAction("TicketEmision", new { token = token });

            var info = await _genericInformation.GetByAccessToken(token);
            if (info.IsSuccessfulWithNoErrors)
            {
                //var jwt = await _jwtService.CreateJwt(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                var countries = await _countriesService.GetAll();
                ViewBag.Countries = countries;
                //ViewBag.Jwt = jwt.Payload.BearerToken;
                ViewBag.Code = info.Payload?.Application.Code;
                ViewBag.Token = token;

                TempData["AccessToken"] = token;
                //TempData["Bearer"] = jwt.Payload.BearerToken;
                return View(info.Payload);
            }
            return RedirectToAction("TravelLogin", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> StepOne(string token, GenericInformationViewModel genericInformation)
        {
            if (ModelState.IsValid)
            {
                //var token = TempData["AccessToken"];
                var result = await _genericInformation.CreateOrUpdate(genericInformation);

                if (result.IsSuccessfulWithNoErrors)
                {
                    return RedirectToAction("StepTwo", new { token = genericInformation.Token });
                }

            }

            var info = await _appService.GetBy(x => x.Id == genericInformation.ApplicationId);
            var countries = await _countriesService.GetAll();
            ViewBag.Countries = countries;
            ViewBag.Code = info.Code;
            ViewBag.Token = genericInformation.Token;
            return View(genericInformation);
        }

        public async Task<IActionResult> StepTwo(string token)
        {
            var isIssued = await CheckEmission(_appService, token, null);
            if (isIssued) return RedirectToAction("TicketEmision", new { token = token });

            TempData["AccessToken"] = token;
            var culture = Request.Cookies["Language"];
            var lang = ClassUtils.GetLangEnum(culture);
            var app = await _appToken.GetByToken(token);
            if (app.IsSuccessfulWithNoErrors)
            {
                var jwt = _jwtService.CreateJwt(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                TempData["Bearer"] = jwt.Payload.BearerToken;
                ViewBag.Jwt = jwt.Payload.BearerToken;
                var gi = await _genericInformation.GetByApplicationId(app.Payload.ApplicationId);
                ViewBag.ApplicationId = app.Payload.ApplicationId;
                ViewBag.Ports = (await _portsService.GetAll(gi.Payload.TransportationMethodId)).Payload;
                ViewBag.Countries = await _countriesService.GetAll();
                ViewBag.MaritalStatus = (await _matStatusService.GetMultilanguage(lang)).Payload;
                ViewBag.Ocupations = (await _ocupationsService.GetMultilanguage(lang)).Payload;
                ViewBag.Airlines = await _airlineService.GetAll();
                ViewBag.Provinces = await _provinceService.GetAll();
                ViewBag.FlightMotives = (await _flightMotivesService.GetMultilanguage(lang)).Payload;
                ViewBag.Hotels = await _hotelService.GetAll();
                ViewBag.GenericInfo = gi.Payload;
                ViewBag.Companions = app.Payload.Application?.Companions;
                ViewBag.Token = token;
                ViewBag.Code = app.Payload.Application.Code;
                var info = await _migratoryInfoService.GetAllMigratoryInformationsByAppId(app.Payload.ApplicationId);
                var viewModel = new MigratoryInfoStepViewModel
                {
                    MigratoryInformations = info,
                    CurrentIndex = info.Any() && info[0].Application.Companions.Equals(info.Count - 1) ? info.Count : info.Count + 1
                };
                return View(viewModel);
            }
            return RedirectToAction("TravelLogin", "Auth");

        }


        [HttpPost]
        public async Task<IActionResult> StepTwo(string token, MigratoryInfoView vm)
        {
            var validator = new MigratoryInformationViewModelValidator(_localizer);
            var validationResult = validator.Validate(vm.MigratoryInformation);
                
            if (!ModelState.IsValid || !validationResult.IsValid)
            {
                var culture = Request.Cookies["Language"];
                validationResult.AddToModelState(ModelState, "MigratoryInformation");
                var lang = ClassUtils.GetLangEnum(culture);
                var app = await _appToken.GetByToken(vm.Token);
                var jwt = _jwtService.CreateJwt(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                TempData["Bearer"] = jwt.Payload.BearerToken;
                ViewBag.Jwt = jwt.Payload.BearerToken;
                var gi = await _genericInformation.GetByApplicationId(app.Payload.ApplicationId);
                ViewBag.ApplicationId = app.Payload.ApplicationId;
                ViewBag.Ports = (await _portsService.GetAll(gi.Payload.TransportationMethodId)).Payload;
                ViewBag.Countries = await _countriesService.GetAll();
                ViewBag.MaritalStatus = (await _matStatusService.GetMultilanguage(lang)).Payload;
                ViewBag.Ocupations = (await _ocupationsService.GetMultilanguage(lang)).Payload;
                ViewBag.Airlines = await _airlineService.GetAll();
                ViewBag.Provinces = await _provinceService.GetAll();
                ViewBag.FlightMotives = (await _flightMotivesService.GetMultilanguage(lang)).Payload;
                ViewBag.Hotels = await _hotelService.GetAll();
                ViewBag.GenericInfo = gi.Payload;
                ViewBag.Companions = app.Payload.Application?.Companions;
                ViewBag.Token = vm.Token;
                var info = await _migratoryInfoService.GetAllMigratoryInformationsByAppId(app.Payload.ApplicationId);

                var viewModel = new MigratoryInfoStepViewModel
                {
                    MigratoryInformations = info,
                    CurrentIndex = vm.PersonIndex
                };
                return View(viewModel);
            }

            RequestResult<MigratoryInformationViewModel> result;
            if (vm.MigratoryInformation.Id > 0)
            {
                result = await _migratoryInfoService.DispatchUpdate(vm.MigratoryInformation);
            }
            else
            {
                result = await _migratoryInfoService.DispatchCreation(vm.MigratoryInformation);
            }

            if (result.IsSuccessfulWithNoErrors)
            {
                var isReadyToDga =
                    await _migratoryInfoService.IsReadyToDga(vm.MigratoryInformation.ApplicationId,
                        vm.GenericInformation.Companions);
                if (isReadyToDga.Payload)
                {
                    var createdEnt =
                        await _customsService.CreateCustomsForEachPerson(vm.MigratoryInformation.ApplicationId);
                    if (createdEnt.IsSuccessfulWithNoErrors)
                    {
                        if (vm.GenericInformation.IsArrival)
                            return RedirectToAction("StepThree", new {token = vm.Token});

                        var culture = Request.Cookies["Language"];
                        var lang = ClassUtils.GetLangEnum(culture);
                        var publicHealth =
                            await _publicHealthService.CreatePublicHealth(vm.MigratoryInformation.ApplicationId, lang);

                        if (publicHealth.IsSuccessfulWithNoErrors)
                        {

                            var isReadyToEmission =
                                await _publicHealthService.IsReadyToEticketEmission(vm.MigratoryInformation.ApplicationId);

                            if (isReadyToEmission.Payload)
                            {
                                var insert = await _eticketsService.PrepareAndCreate(vm.MigratoryInformation.ApplicationId);
                                if (insert.IsSuccessfulWithNoErrors)
                                {
                                    await _appService.UpdateStatus(vm.MigratoryInformation.ApplicationId, StatusEnum.Completed);
                                }
                                await _eticketsService.SavePassengersIntoImi(vm.MigratoryInformation.ApplicationId);
                                return RedirectToAction("TicketEmision", "TravelTicket", new { token = vm.Token });
                            }
                            
                        }
                    }
                }

                return RedirectToAction("StepTwo", new { token = vm.Token });
            }

            if (result.Code.Equals((int)CommonError.RepeatedPassport))
            {
                ShowNotification(_localizer["Notice"], $"{_localizer["Val.RepeatedPassport"]} <b>{vm.MigratoryInformation.PassportNumber}</b>", "warning");
                var culture = Request.Cookies["Language"];
                var lang = ClassUtils.GetLangEnum(culture);
                var app = await _appToken.GetByToken(vm.Token);
                var jwt = _jwtService.CreateJwt(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
                TempData["Bearer"] = jwt.Payload.BearerToken;
                ViewBag.Jwt = jwt.Payload.BearerToken;
                var gi = await _genericInformation.GetByApplicationId(app.Payload.ApplicationId);
                ViewBag.ApplicationId = app.Payload.ApplicationId;
                ViewBag.Ports = (await _portsService.GetAll(gi.Payload.TransportationMethodId)).Payload;
                ViewBag.Countries = await _countriesService.GetAll();
                ViewBag.MaritalStatus = (await _matStatusService.GetMultilanguage(lang)).Payload;
                ViewBag.Ocupations = (await _ocupationsService.GetMultilanguage(lang)).Payload;
                ViewBag.Airlines = await _airlineService.GetAll();
                ViewBag.Provinces = await _provinceService.GetAll();
                ViewBag.FlightMotives = (await _flightMotivesService.GetMultilanguage(lang)).Payload;
                ViewBag.Hotels = await _hotelService.GetAll();
                ViewBag.GenericInfo = gi.Payload;
                ViewBag.Companions = app.Payload.Application?.Companions;
                ViewBag.Token = vm.Token;
                var info = await _migratoryInfoService.GetAllMigratoryInformationsByAppId(app.Payload.ApplicationId);
                ModelState.Clear();

                var viewModel = new MigratoryInfoStepViewModel
                {
                    MigratoryInformations = info,
                    CurrentIndex = vm.PersonIndex
                };

                return View(viewModel);
            }

            return RedirectToAction("StepTwo", new { token = vm.Token });
        }

        public async Task<IActionResult> StepThree(string token)
        {
            var isIssued = await CheckEmission(_appService, token, null);
            if (isIssued) return RedirectToAction("TicketEmision", new { token = token });

            var app = await _appToken.GetByToken(token);
            if (app.IsSuccessfulWithNoErrors)
            {
                // string bearer = TempData["Bearer"].ToString();
                ViewBag.ApplicationId = app.Payload.ApplicationId;
                ViewBag.Token = token;
                ViewBag.Currencies = (await _currencyService.GetAll()).ToList().OrderBy(x => x.Name);
                ViewBag.Code = app.Payload.Application.Code;
                var info = await _migratoryInfoService.GetByApplicationIdAndCustoms(app.Payload.ApplicationId);
                info.Payload.PersonIndex = 1;
                info.Payload.PreviousIndex = 0;
                var id = app.Payload.Id;
                return View(info.Payload);
            }
            return RedirectToAction("TravelLogin", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> StepThree(string token, CustomsInformationWiewModel customs)
        {
            var json = JsonSerializer.Serialize(customs);
            var validator = new CustomsInformationWiewModelValidatorNoMsg();
            var validatorValue = validator.Validate(customs);
            if (validatorValue.IsValid)
            {
                var culture = Request.Cookies["Language"];
                var lang = ClassUtils.GetLangEnum(culture);
                var result = await _customsService.UpdateWithConditions(customs);

                if (result.IsSuccessfulWithNoErrors)
                {
                    var phReady = _customsService.IsPublicHealthReady(customs.ApplicationId, customs.PersonIndex);
                    if (phReady.IsSuccessfulWithNoErrors && phReady.Payload)
                    {
                        var phResult =
                            await _publicHealthService.CreatePublicHealth(customs.ApplicationId, lang);

                        if (phResult.IsSuccessfulWithNoErrors)
                            return RedirectToAction("Index", "PublicHealths", new { token = customs.Token });

                    }

                    ModelState.Clear();
                    var app = await _appToken.GetByToken(customs.Token);
                    if (app.IsSuccessfulWithNoErrors)
                    {
                        ViewBag.ApplicationId = app.Payload.ApplicationId;
                        ViewBag.Token = customs.Token;
                        ViewBag.Currencies = (await _currencyService.GetAll()).ToList().OrderBy(x => x.Name);
                        var list = await _migratoryInfoService.GetByApplicationIdAndCustoms(app.Payload.ApplicationId);
                        list.Payload.PersonIndex = customs.PersonIndex + 1;
                        list.Payload.PreviousIndex = customs.PersonIndex;

                        return View("StepThree", list.Payload);
                    }

                }

                return RedirectToAction("StepThree", new { token = customs.Token });
            }

            ModelState.Clear();
            ViewBag.ApplicationId = customs.ApplicationId;
            ViewBag.Token = customs.Token;
            ViewBag.Currencies = (await _currencyService.GetAll()).ToList().OrderBy(x => x.Name);
            var info = await _migratoryInfoService.GetByApplicationIdAndCustoms(customs.ApplicationId);
            info.Payload.PersonIndex = customs.PersonIndex + 1;
            info.Payload.PreviousIndex = customs.PersonIndex;
            var infoList = info.Payload.MigratoryInformation;
            infoList[
                    infoList.FindIndex(x =>
                        x.CustomsInformation.MigratoryInformationId.Equals(customs.MigratoryInformationId))]
                .CustomsInformation = customs;

            return View("StepThree", info.Payload);
        }


        [HttpGet]
        public async Task<IActionResult> TicketEmision(string token, bool isPrint = false)
        {
            var reqResult = await _appToken.GetByToken(token);
            if (reqResult.IsSuccessfulWithNoErrors)
            {
                var eticketEmission = await _eticketsService.GetByApplicationIdInclude(reqResult.Payload.ApplicationId);
                if (eticketEmission.IsSuccessfulWithNoErrors)
                {
                    var emission = new EmissionViewModel
                    {
                        Eticket = eticketEmission.Payload,
                        QrCode = ClassUtils.Generate(eticketEmission.Payload.Sequence),
                        IsPrint = isPrint,
                        Token = token
                    };
                    return View(emission);
                }
            }
            return RedirectToAction("TravelLogin", "Auth");
        }


        [HttpGet]
        public IActionResult GeneratePdf(string token)
        {
            HtmlToPdf conv = new HtmlToPdf();
            conv.Options.WebPageWidth = 1900;
            conv.Options.WebPageHeight = 150;
            conv.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
          
            var url = $"{_pdfUrl.Value.Url}{token}&isPrint=true";
            //var url = $"~/TravelTicket/TicketEmision?token={token}&isPrint=true";
           
         PdfDocument doc = conv.ConvertUrl(url);
            // conv.
            var document = doc.Save();

            doc.Close();
            return File(document, "application/pdf", $"E-Ticket_{Guid.NewGuid()}.pdf");
        }


    }
}