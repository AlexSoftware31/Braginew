using System.Linq;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.BussinessLayer.Interfaces.Steps;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Auth;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.DgaVm;
using Bragi.DataLayer.ViewModels.UpdateStep;
using Microsoft.EntityFrameworkCore;
using NetCoreUtilities.Extensions;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.Applications
{
    public class ApplicationsService : BaseService<Application, ProyectDbContext, ApplicationViewModel>, IApplicationsService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationTokenService _appToken;
        private readonly IStepsService _stepsService;
        private readonly IEticketsService _etickets;
        public ApplicationsService(ProyectDbContext context,
            IMapper mapper, IApplicationTokenService appToken,
            IStepsService stepsService, IEticketsService etickets

        ) : base(context, mapper)
        {
            _mapper = mapper;
            _appToken = appToken;
            _stepsService = stepsService;
            _etickets = etickets;
        }

        public async Task<RequestResult<ApplicationViewModel>> CreateApplication(AuthViewModel auth)
        {
            var appCode = RandomGeneration.GenerateApplicationNumber(6);
            auth.ApplicationCode = appCode;
            var md5Code = RandomGeneration.ApplicationMd5Gen(auth);
            var step = await _stepsService.GetBy(x => x.StepsEnum == StepsEnum.GeneralInformation);
            var app = new Application
            {
                Code = appCode,
                Companions = auth.AcompanyNumber,
                StatusId = (int)StatusEnum.Open,
                StepId = step.Id,
                ApplicationToken = new ApplicationToken
                {
                    Token = md5Code,
                    IsDisable = false
                },
                GenericInformation = new GenericInformation
                {
                    Companions = auth.AcompanyNumber
                }
            };
            return await CreateAsync(app);
        }

        public async Task<RequestResult<ApplicationViewModel>> DidExistReturnInfo(string token)
        {
            var reqResult = RequestResult<ApplicationViewModel>.Failed();
            var applicationDidExist = await _appToken.GetQueryable(x => x.Token == token).FirstOrDefaultAsync();
            if (applicationDidExist != null)
            {
                var appVieModel = await GetQueryable(x => x.Id == applicationDidExist.ApplicationId)
                    .Include(x => x.Step)
                    .FirstOrDefaultAsync();
                var mapped = _mapper.Map<ApplicationViewModel>(appVieModel);
                if (mapped == null) return reqResult;
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }
            return reqResult;
        }

        public async Task<bool> DidExist(string token)
        {
            return await _appToken.AnyAsync(x => x.Token == token);
        }

        public async Task<RequestResult<ApplicationViewModel>> UpdateStep(UpdateStepViewModel update)
        {
            var application = await GetEntityByIdAsync(update.ApplicationId);
            var step = await _stepsService.GetBy(x => x.StepsEnum == update.StepsEnum);
            application.StepId = step.Id;
            if (update.StepsEnum == StepsEnum.Submitted)
            {
                var reqResult = await _etickets.PrepareAndCreate(application.Id);
                if (reqResult.IsSuccessfulWithNoErrors)
                {
                    var saveToImi = await _etickets.SavePassengersIntoImi(application.Id);
                    if (saveToImi.IsSuccessfulWithNoErrors)
                    {
                        application.StatusId = (int)StatusEnum.Completed; //Added on 08/10/2020
                        return await EditAsync(application);
                    }
                    return RequestResult<ApplicationViewModel>.Failed("There Was an Error Creating the E-Ticket Emission", "Service: ETicketService").AddError(reqResult.GetMessageErrorBody().Message);
                }
                return RequestResult<ApplicationViewModel>.Failed("There Was an Error Creating the E-Ticket Emission", "Service: ETicketService").AddError(reqResult.GetMessageErrorBody().Message);
            }
            return await EditAsync(application);
        }

        public async Task<RequestResult<ApplicationViewModel>> UpdateTermsAndConditions(int applicationId)
        {
            var app = await FindBy(x => x.Id == applicationId).FirstOrDefaultAsync();
            app.HasAcceptedTerms = true;
            return await EditAsync(app);
        }

        public async Task<RequestResult<DgaOutputViewModel>> GetDgaOutputModel(OutputParams outputParams)
        {
            var reqResult = RequestResult<DgaOutputViewModel>.Failed();

            var emission = await _etickets.GetByApplicationId(outputParams.ApplicationId);
            if (emission != null)
            {
                var info = await GetQueryable(x => x.Id == outputParams.ApplicationId)
                    .Include(x => x.GenericInformation)
                    .ThenInclude(x => x.TransportationMethod)
                    .Include(x => x.MigratoryInformations)
                    .ThenInclude(x => x.CustomsInformation)
                    .ThenInclude(x => x.DeclaredMerchs)
                    .Include(x => x.MigratoryInformations)
                    .ThenInclude(x => x.FlightMotive)
                    .Include(x => x.MigratoryInformations)
                    .ThenInclude(x => x.Hotel)
                    .Include(x => x.MigratoryInformations)
                    .ThenInclude(x => x.MaritalStatus)
                    .Include(x => x.MigratoryInformations)
                    .ThenInclude(x => x.Ocupation)
                    .Include(x => x.MigratoryInformations).ThenInclude(x => x.Airline)
                    .FirstOrDefaultAsync();
                if (info != null)
                {
                    var res = _mapper.Map<DgaOutputViewModel>(info);
                    res.QrCode = emission.Payload.Sequence;
                    reqResult.SetSucceeded(res);
                    return reqResult;
                }
            }
            return reqResult.AddError($"There is no emission for the ApplicationId: {outputParams.ApplicationId}");
        }

        public async Task<RequestResult> SetAssistant(AssistantViewModel assistant)
        {
            var app = await FindBy(x => x.Id == assistant.ApplicationId).FirstOrDefaultAsync();
            app.AssistantName = assistant.AssistantName;
            app.AssistantRelation = assistant.AssistantRelation;
            app.WasAssisted = true;
            return await EditAsync(app);
        }

        public async Task<RequestResult> UpdateStatus(int applicationId, StatusEnum status)
        {
            var app = await GetAsync(x => x.Id == applicationId);
            app.StatusId = (int)status;
            return await EditAsync(app);
        }

        public async Task<RequestResult<bool>> IsEticketEmited(string accessToken, int? applicationId)
        {
            if (string.IsNullOrEmpty(accessToken) && applicationId == null || applicationId == 0)
            {
                return RequestResult<bool>.Failed();
            }
            var query = GetQueryable();
            if (!string.IsNullOrEmpty(accessToken))
            {
                query = query.Where(x => x.StatusId == (int)StatusEnum.Completed && x.ApplicationToken.Token == accessToken);
            }

            if (applicationId > 0)
            {
                query = query.Where(x => x.StatusId == (int)StatusEnum.Completed && x.Id == applicationId);
            }

            var result = await query.Select(x=> x.Id).AnyAsync();
            if (result)
            {
                return RequestResult<bool>.Success(true);
            }
            return RequestResult<bool>.Success(false);
        }
    }
}
