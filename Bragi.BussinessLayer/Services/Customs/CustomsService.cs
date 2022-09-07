using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.RequestLogs;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Configuration.OptionsModel;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.Models.RequestLogs;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.DgaVm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetCoreUtilities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.Customs
{
    public class CustomsService : BaseService<CustomsInformation, ProyectDbContext, CustomsInformationWiewModel>, ICustomsService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationsService _applicationsService;
        private readonly IRequestLogService _requestLogService;
        private readonly DgaRouteConfig _dgaRoute;
        private readonly IMigratoryInfoService _migratoryInfoService;

        public CustomsService(ProyectDbContext context, IMapper mapper,
            IApplicationsService applicationsService,
            IRequestLogService requestLogService,
            IOptions<DgaRouteConfig> dgaOptions,
            IMigratoryInfoService migratoryInfoService
            ) : base(context, mapper)
        {
            _mapper = mapper;
            _applicationsService = applicationsService;
            _requestLogService = requestLogService;
            _dgaRoute = dgaOptions.Value;
            _migratoryInfoService = migratoryInfoService;
        }

        public async Task<RequestResult<IEnumerable<CustomsInformationWiewModel>>> GetByApplicationId(int applicationId)
        {
            var reqResult = RequestResult<IEnumerable<CustomsInformationWiewModel>>.Failed();
            var list = await GetList(x => x.ApplicationId == applicationId);
            if (list.Any())
            {
                var mapped = _mapper.Map<IEnumerable<CustomsInformationWiewModel>>(list);
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }
            return reqResult;
        }

        public async Task<RequestResult<CustomsInformationWiewModel>> UpdateWithConditions(CustomsInformationWiewModel entity)
        {
            var entityMap = _mapper.Map<CustomsInformation>(entity);
            var declaredMerch = _mapper.Map<DeclaredMerch>(entity.DeclaredMerch);
            if (declaredMerch != null) declaredMerch.CustomsInformationId = entityMap.Id;

            entityMap.MigratoryInformation = null;
            if (entityMap.IsValuesOwner)
            {
                entityMap.SenderName = null;
                entityMap.SenderLastName = null;
                entityMap.ReceiverName = null;
                entityMap.ReceiverLastName = null;
                entityMap.WorthDestiny = null;
                entityMap.RelationShip = null;
            }
            if (!entityMap.HasMerchWithTaxValue)
            {
                entityMap.ValueOfMerchandise = 0;
                entityMap.CurrencyMerchandiseId = null;
                if (entityMap.DeclaredMerchs.Any(x => !x.IsDeleted))
                {
                    foreach (var merch in entityMap.DeclaredMerchs)
                    {
                        merch.IsDeleted = true;
                    }
                }
            }

            if (entity.DeclaredMerch != null)
            {
                entityMap.DeclaredMerchs = new List<DeclaredMerch> { declaredMerch };
            }

            return await EditAsync(entityMap);
        }

        public async Task<RequestResult<DgaOutputViewModel>> SendInformationToCustomsWs(OutputParams outputParams)
        {

            var reqResult = await _applicationsService.GetDgaOutputModel(outputParams);

            if (reqResult.IsSuccessfulWithNoErrors)
            {
                using (var client = new HttpClient())
                {


                    var credentials = Encoding.ASCII.GetBytes($"{_dgaRoute.User}:{_dgaRoute.Password}");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
                    client.BaseAddress = new Uri(_dgaRoute.BaseUrl); //TODO: Put Here DGA Endpoint
                    var sw = new Stopwatch();
                    sw.Start();
                    var result = await client.PostAsJsonAsync($"{_dgaRoute.Route}", reqResult);
                    sw.Stop();

                    var log = new RequestLog
                    {
                        Method = "Post",
                        RequestBody = JsonConvert.SerializeObject(reqResult).Trim(),
                        RequestHeader = result.Content?.Headers.ToString(),
                        RequestMils = sw.ElapsedMilliseconds,
                        Uri = $"{_dgaRoute.BaseUrl}{_dgaRoute.Route}",
                        StatusCode = result.StatusCode.ToString(),
                        ResponseBody = (await result.Content.ReadAsStringAsync())?.Trim()
                    };
                    await _requestLogService.AddAsync(log);
                    await _requestLogService.CommitAsync();
                    return reqResult;
                }
            }
            return reqResult;
        }

        public async Task<RequestResult> CreateCustomsForEachPerson(int applicationId)
        {
            var migratories = await _migratoryInfoService.GetQueryable(x => x.ApplicationId == applicationId).Select(x => x.Id).ToListAsync();

            if (migratories != null)
            {
                var customsList = new List<CustomsInformation>();
                migratories.ForEach(migratory =>
                {
                    customsList.Add(new CustomsInformation
                    {
                        ApplicationId = applicationId,
                        MigratoryInformationId = migratory
                    });
                });
                if (!await AnyAsync(x => x.ApplicationId == applicationId))
                {
                    var res = await CreateRange(customsList);
                    return res;
                }
                return RequestResult.Success();
            }
            return RequestResult.Failed($"Cannot Find the App Id: {applicationId}");
        }

        public  RequestResult<bool> IsPublicHealthReady(int applicationId, int personIndex)
        {
            var result = RequestResult<bool>.Failed();
            var applicationsTotal = GetQueryable(x => x.ApplicationId == applicationId).Count();
            return result.SetSucceeded(personIndex.Equals(applicationsTotal));
        }
    }
}