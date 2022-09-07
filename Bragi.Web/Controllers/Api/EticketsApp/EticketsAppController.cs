using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.DataLayer;
using Bragi.DataLayer.Enums;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.ETickets;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.Validators.Customs;
using Bragi.DataLayer.Validators.MigratoryInfo;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Auth;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.ETickets;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.DataLayer.ViewModels.Questions;
using Bragi.Web.Controllers.Core;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NetCoreUtilities.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.Web.Controllers.Api.EticketsApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class EticketsAppController : ControllerBase
    {
        private readonly IApplicationsService _applicationService;
        private readonly IGenericInformationService _genericInformation;
        private readonly IEticketsService _eticketsService;
        private readonly IPublicHealthService _publicHealthService;
        private readonly ICustomsService _customsService;
        private readonly IApplicationTokenService _appToken;
        private readonly IMigratoryInfoService _migratoryInfoService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IQuestionResponseService _responseService;
        private readonly IDeclaredMerchService _declaredMerchService;
        private readonly IPublicHealthCountriesService _publicHealthCountriesService;
        public EticketsAppController(IEticketsService eticketsService,
            IGenericInformationService genericInformation,
            IPublicHealthService publicHealthService,
            ICustomsService customsService,
            IApplicationsService appService,
            IMigratoryInfoService migratoryInfoService,
            IStringLocalizer<SharedResource> localizer,
            IApplicationTokenService appToken,
            IQuestionResponseService responseService,
            IDeclaredMerchService declaredMerchService,
            IPublicHealthCountriesService publicHealthCountriesService
             )
        {
            _eticketsService = eticketsService;
            _genericInformation = genericInformation;
            _publicHealthService = publicHealthService;
            _customsService = customsService;
            _applicationService = appService;
            _migratoryInfoService = migratoryInfoService;
            _localizer = localizer;
            _appToken = appToken;
            _responseService = responseService;
            _declaredMerchService = declaredMerchService;
            _publicHealthCountriesService = publicHealthCountriesService;
        }

        [HttpGet("request-travel")]
        public async Task<IActionResult> RequestTravel(string key)
        {
            #region Key
            string statickey = "tanDtZX6FYzUh9gSY7UgyHX6pHTKmtz9Q76iFy9NLMvuFGXaxXrGX4MqjQu";
            #endregion

            if (key != statickey)
                return BadRequest(new { message = "Key invalida" });

            AuthViewModel auth = new AuthViewModel();
            var opResult = await _applicationService.CreateApplication(auth);

            if (opResult.IsSuccessfulWithNoErrors)
            {
                return Ok(new
                {
                    opResult.Payload.ApplicationToken.Token,
                    ApplicationId = opResult.Payload.Id,
                    opResult.Payload.GenericInformation.Id
                });
            }

            return BadRequest(opResult.Errors);
        }

        [HttpPost("step-one")]
        public async Task<IActionResult> StepOne(GenericInformationViewModel genericInformation)
        {
            if (ModelState.IsValid)
            {
                #region ValueDefault
                genericInformation.TransportationMethodId = 3;
                #endregion
                var result = await _genericInformation.CreateOrUpdate(genericInformation);

                if (result.IsSuccessfulWithNoErrors)
                {
                    return Ok(new {token= genericInformation.Token, mensage = "Go to step-two" });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("step-two")]
        public async Task<IActionResult> StepTwo(MigratoryInfoView vm)
        {
            var validator = new MigratoryInformationViewModelValidator(_localizer);
            var validationResult = validator.Validate(vm.MigratoryInformation);

            if (!ModelState.IsValid || !validationResult.IsValid)
            {
                if (ModelState.IsValid)
                {
                    return BadRequest(validationResult);
                }
                else
                {
                    return BadRequest(ModelState);
                }
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
                        {
                            var customs = await _customsService.GetByApplicationId(vm.MigratoryInformation.ApplicationId);

                            List <CustomsReponse> customsReponse = new List<CustomsReponse>();

                            foreach (CustomsInformationWiewModel customsInformation in customs.Payload)
                            {
                                customsReponse.Add(new CustomsReponse
                                {
                                    CustomId = customsInformation.Id,
                                    MigratoryInformationId = customsInformation.MigratoryInformationId
                                });
                            }
                           
                            return Ok(new { token = vm.Token, mensage = "Go to step-three", stepThreeInfo = customsReponse});
                        }

                        var culture = Request.Cookies["Language"];
                        var lang = ClassUtils.GetLangEnum(culture);
                        var publicHealth =
                            await _publicHealthService.CreatePublicHealth(vm.MigratoryInformation.ApplicationId, lang);


                        if (publicHealth.IsSuccessfulWithNoErrors)
                        {

                            var isReadyToEmission =
                                await _publicHealthService.IsReadyToEticketEmission(vm.MigratoryInformation.ApplicationId);

                            if (isReadyToEmission.Succeeded)
                            {
                                var insert = await _eticketsService.PrepareAndCreate(vm.MigratoryInformation.ApplicationId);
                                if (insert.IsSuccessfulWithNoErrors)
                                {
                                    await _applicationService.UpdateStatus(vm.MigratoryInformation.ApplicationId, StatusEnum.Completed);
                                }
                                await _eticketsService.SavePassengersIntoImi(vm.MigratoryInformation.ApplicationId);
                                var eticketEmission = await _eticketsService.GetByApplicationIdInclude(vm.MigratoryInformation.ApplicationId);
                                return Ok(new { token = vm.Token, qrcode = eticketEmission.Payload.Sequence });
                            }
                        }

                        return BadRequest(publicHealth.Errors);
                    }
                }
                return Ok(new { token = vm.Token, mensage = "Next Person" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("step-three")]
        public async Task<IActionResult> StepThree(FormCustomsInformation customs)
        {
            foreach (DeclaredMerch declared in customs.DeclaredMerchs)
            {
                declared.CustomsInformationId = customs.CustomsInformation.Id;
                await _declaredMerchService.CreateAsync(declared);
            }

            var validator = new CustomsInformationWiewModelValidatorNoMsg();
            var validatorValue = validator.Validate(customs.CustomsInformation);
            if (validatorValue.IsValid)
            {
                var culture = Request.Cookies["Language"];
                var lang = ClassUtils.GetLangEnum(culture);
                var result = await _customsService.UpdateWithConditions(customs.CustomsInformation);

                if (result.IsSuccessfulWithNoErrors)
                {
                    var phReady = _customsService.IsPublicHealthReady(customs.CustomsInformation.ApplicationId, customs.CustomsInformation.PersonIndex);
                    if (phReady.IsSuccessfulWithNoErrors && phReady.Payload)
                    {
                        var phResult = await _publicHealthService.CreatePublicHealth(customs.CustomsInformation.ApplicationId, lang);

                        var resultPublic = await _publicHealthService.GetByApplicationId(customs.CustomsInformation.ApplicationId);

                        List<PublicHealthReponse> publicHealthReponse = new List<PublicHealthReponse>();

                        foreach (PublicHealthViewModel publicHealth in resultPublic.Payload)
                        {
                            publicHealthReponse.Add(new PublicHealthReponse
                            {
                                PublicHealthId = publicHealth.Id,
                                MigratoryInformationId = publicHealth.MigratoryInformationId
                            });
                        }

                        if (phResult.IsSuccessfulWithNoErrors)
                            return Ok(new { token = customs.CustomsInformation.Token, mensage = "PublicHealthForm", publicHealthInfo = publicHealthReponse });
                    }

                    return Ok(new { token = customs.CustomsInformation.Token, mensage = "Next Person" });
                }

                return BadRequest(result);
            }

            return BadRequest(validatorValue);
        }


        [HttpPost("public-health")]
        public async Task<IActionResult> PublicHealth([CustomizeValidator(Skip = true)] FormPublicHealth phViewModel)
        {
            //Countries
            foreach (int countrieid in phViewModel.Countries)
            {
                PublicHealthCountries countrie = new PublicHealthCountries
                {
                    CountryId = countrieid,
                    PublicHealthId = phViewModel.PublicHealth.Id
                };

                await _publicHealthCountriesService.CreateAsync(countrie);
            }

            //Response
            var response = await  _responseService.FindBy(r => r.PublicHealthId == phViewModel.PublicHealth.Id && phViewModel.Symptoms.Any(q=> q == r.QuestionId)).ToListAsync();
           
            foreach(QuestionResponse question in response)
            {
               question.BoolResponse = true;
               await _responseService.EditAsync(question);
            }

            //Public Health
            phViewModel.PublicHealth.QuestionResponse = null;
            var result = await _publicHealthService.EditAsync(phViewModel.PublicHealth);

            var isReadyToEmission =
                await _publicHealthService.IsReadyToEticketEmission(phViewModel.PublicHealth.ApplicationId, phViewModel.PublicHealth.PersonIndex);
            if (result.IsSuccessfulWithNoErrors)
            {
                if (isReadyToEmission.Payload)
                {
                    var insert = await _eticketsService.PrepareAndCreate(phViewModel.PublicHealth.ApplicationId);
                    if (insert.IsSuccessfulWithNoErrors)
                    {
                        await _applicationService.UpdateStatus(phViewModel.PublicHealth.ApplicationId, StatusEnum.Completed);
                    }
                    await _eticketsService.SavePassengersIntoImi(phViewModel.PublicHealth.ApplicationId);
                    var eticketEmission = await _eticketsService.GetByApplicationIdInclude(phViewModel.PublicHealth.ApplicationId);
                    return Ok(new { token = phViewModel.PublicHealth.Token, qrcode = eticketEmission.Payload.Sequence });
                }


                return Ok(new { token = phViewModel.PublicHealth.Token, message = "Next Person"});
            }

            var miResult2 = await _migratoryInfoService.GetByApplicationIdAndPublicHealth(phViewModel.PublicHealth.ApplicationId);

            return BadRequest(new { token = phViewModel.PublicHealth.Token, miResult2.Payload });
        }

       


    }

    public class FormPublicHealth {
        public PublicHealthViewModel PublicHealth { get; set; }
        public int[] Symptoms { get; set; }
        public int[] Countries { get; set; }
    }

    public class FormCustomsInformation{
       public  CustomsInformationWiewModel CustomsInformation { get; set; }
       public List<DeclaredMerch> DeclaredMerchs { get; set; }
    }

    public class PublicHealthReponse
    {
        public int PublicHealthId { get; set; }
        public int MigratoryInformationId { get; set; }
    }

    public class CustomsReponse
    {
        public int CustomId { get; set; }
        public int MigratoryInformationId { get; set; }
    }
}
