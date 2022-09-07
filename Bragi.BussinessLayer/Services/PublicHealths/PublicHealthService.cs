using AutoMapper;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.Validators.PublicHealth;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.DataLayer.ViewModels.Questions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Services.PublicHealths
{
    public class PublicHealthService : BaseService<PublicHealth, ProyectDbContext, PublicHealthViewModel>, IPublicHealthService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionsService _questionsService;
        private readonly IMigratoryInfoService _migratoryInfoService;
        private readonly IQuestionResponseService _questionResponseService;
        public PublicHealthService(ProyectDbContext context, IMapper mapper,
            IQuestionsService questionsService,
            IMigratoryInfoService migratoryInfoService,
            IQuestionResponseService questionResponseService
            ) : base(context, mapper)
        {
            _mapper = mapper;
            _questionsService = questionsService;
            _migratoryInfoService = migratoryInfoService;
            _questionResponseService = questionResponseService;
        }

        public async Task<RequestResult<IEnumerable<PublicHealthViewModel>>> GetByApplicationId(int applicationId)
        {
            var reqResult = RequestResult<IEnumerable<PublicHealthViewModel>>.Failed();
            var list = await GetQueryable(x => x.ApplicationId == applicationId).Include(x => x.Application)
                .Include(x => x.MigratoryInformation)
                .Include(x => x.QuestionResponse)
                .ThenInclude(x => x.Question)
                .Include(x => x.PublicHealthCountries)
                .Include(x => x.PublicHealthStopOvers).ToListAsync();


            if (list.Any())
            {
                var mapped = _mapper.Map<IEnumerable<PublicHealthViewModel>>(list);
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }
            return reqResult;
        }

        public async Task<RequestResult> CreatePublicHealth(int applicationId, LanguageEnum lang = LanguageEnum.Spanish)
        {

            var isAlreadyCreated = await AnyAsync(x => x.ApplicationId == applicationId);
            if (isAlreadyCreated) return RequestResult.Success();

            if (applicationId > 0)
            {
                var phCreateResult = await CreatePublicHealths(applicationId);
                if (phCreateResult.IsSuccessfulWithNoErrors)
                {
                    return await CreateQuestionResponseForEachPublicHealth(phCreateResult.Payload);
                }
                return phCreateResult;
            }
            return RequestResult.Failed($"Cannot Find the App Id: {applicationId}");
        }

        private async Task<RequestResult<List<PublicHealthViewModel>>> CreatePublicHealths(int applicationId)
        {
            var milist = await _migratoryInfoService.GetQueryable(x => x.ApplicationId == applicationId)
                .Select(x => x.Id).ToListAsync();
            var phList = new List<PublicHealth>();
            milist.ForEach(migratoryInformationId =>
            {
                phList.Add(new PublicHealth
                {
                    ApplicationId = applicationId,
                    MigratoryInformationId = migratoryInformationId
                });
            });

            var result = await CreateRange(phList);

            return result;
        }

        private async Task<RequestResult<List<QuestionResponseViewModel>>> CreateQuestionResponseForEachPublicHealth(
            List<PublicHealthViewModel> phViewModel)
        {
            var questions =
                await _questionsService.GetByTypeAndAgency(QuestionsTypeEnum.PublicHealth, AgenciesEnum.PublicHeath,
                    LanguageEnum.Spanish);
            var questionResposes = new List<QuestionResponse>();

            foreach (var ph in phViewModel)
            {
                questions.Payload.ForEach(q =>
                {
                    questionResposes.Add(new QuestionResponse
                    {
                        PublicHealthId = ph.Id,
                        QuestionId = q.Id,
                        BoolResponse = false
                    });
                });
            }
            var qrResult = await _questionResponseService.CreateRange(questionResposes);
            if (qrResult.IsSuccessfulWithNoErrors) return qrResult;
            return RequestResult<List<QuestionResponseViewModel>>.Failed("Error Creating Question Responses.");
        }


        public async Task<RequestResult<PublicHealthViewModel>> EditAsync(PublicHealthViewModel viewModel)
        {
            var mapped = _mapper.Map<PublicHealth>(viewModel);
            return await EditAsync(mapped);
        }

        public async Task<RequestResult<bool>> IsReadyToEticketEmission(int applicationId, int personIndex)
        {
            var result = RequestResult<bool>.Failed();
            var applicationsTotal = await GetQueryable(x => x.ApplicationId == applicationId)
                .Include(x => x.Application).ThenInclude(a => a.GenericInformation)
                .Include(x => x.MigratoryInformation)
                .Include(x => x.QuestionResponse)
                .ToListAsync();

            if (!applicationsTotal.Any())
            {
                result = RequestResult<bool>.Failed("NO HAY DATOS");
                return result;
            }

            var validator = new PublicHealthValidator();
            applicationsTotal.ForEach(async x =>
            {
                var mapped = _mapper.Map<PublicHealthViewModel>(x);
                if (x.Application.GenericInformation.IsArrival)
                {
                    var validationResult = await validator.ValidateAsync(mapped);
                    if (!validationResult.IsValid)
                    {
                        foreach (var validationResultError in validationResult.Errors)
                        {
                            result.AddError(validationResultError.ErrorMessage);
                        }
                    }
                }
            });

            return result.SetSucceeded(!result.HasErrors && applicationsTotal.Count.Equals(personIndex));
        }

        public async Task<RequestResult<bool>> IsReadyToEticketEmission(int applicationId)
        {
            var result = RequestResult<bool>.Failed();
            var applicationsTotal = await GetQueryable(x => x.ApplicationId == applicationId)
                .Include(x => x.Application).ThenInclude(a => a.GenericInformation)
                .Include(x => x.MigratoryInformation)
                .Include(x => x.QuestionResponse)
                .ToListAsync();

            if (!applicationsTotal.Any())
            {
                result = RequestResult<bool>.Failed("NO HAY DATOS");
                return result;
            }

            var validator = new PublicHealthValidator();
            applicationsTotal.ForEach(async x =>
            {
                var mapped = _mapper.Map<PublicHealthViewModel>(x);
                if (x.Application.GenericInformation.IsArrival)
                {
                    var validationResult = await validator.ValidateAsync(mapped);
                    if (!validationResult.IsValid)
                    {
                        foreach (var validationResultError in validationResult.Errors)
                        {
                            result.AddError(validationResultError.ErrorMessage);
                        }
                    }
                }
            });

            return result.SetSucceeded(!result.HasErrors);
        }
        
        public override async Task<RequestResult<PublicHealthViewModel>> EditAsync(PublicHealth entity)
        {

            return await base.EditAsync(entity);
        }

    }
}
