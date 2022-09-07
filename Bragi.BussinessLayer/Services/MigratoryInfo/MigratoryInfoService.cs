using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Enums;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Microsoft.EntityFrameworkCore;
using NetCoreUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.MigratoryInfo
{
    public class MigratoryInfoService : BaseService<MigratoryInformation, ProyectDbContext, MigratoryInformationViewModel>, IMigratoryInfoService
    {
        private readonly IMapper _mapper;
        private readonly ISectorsService _sectorsService;
        private readonly IPublicHealthValidatorService _publicHealthValidatorService;

        public MigratoryInfoService(ProyectDbContext context, IMapper mapper, ISectorsService sectorsService, IPublicHealthValidatorService publicHealthValidatorService) : base(context, mapper)
        {
            _mapper = mapper;
            _sectorsService = sectorsService;
            _publicHealthValidatorService = publicHealthValidatorService;
        }

        public async Task<RequestResult<List<MigratoryInformationViewModel>>> GetInformationByApplicationId(int applicationId)
        {
            var reqResult = RequestResult<List<MigratoryInformationViewModel>>.Failed();
            var list = await GetQueryable(x => x.ApplicationId == applicationId)
                .Include(x => x.Application)
                .ToListAsync();
            var mapped = _mapper.Map<List<MigratoryInformationViewModel>>(list);

            mapped.ForEach(x =>
            {
                if (string.IsNullOrEmpty(x.GeoCode))
                {
                    x.Sector = new SectorsViewModel();
                }
                else
                {
                    x.Sector = _sectorsService.GetQueryable(a => a.GeoCode == x.GeoCode)
                        .ProjectTo<SectorsViewModel>(_mapper.ConfigurationProvider)
                        .FirstOrDefault();
                }
            });

            if (mapped.Any())
            {
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }
            return reqResult;
        }

        public async Task<RequestResult<MigratoryInformationViewModel>> DispatchCreation(MigratoryInformationViewModel entity)
        {
            bool isPrincipal = !await AnyAsync(x => x.ApplicationId == entity.ApplicationId);
            entity.IsPrincipal = isPrincipal;

            if (entity.TaxReturnInfo.Cedula != null)
            {
                entity.TaxReturnInfo.Cedula = entity.TaxReturnInfo.Cedula.Replace("-", "");
                entity.TaxReturnInfo.Telefono = entity.TaxReturnInfo.Telefono.Replace("-", "");
            }

            if (!entity.IsPrincipal && string.IsNullOrEmpty(entity.GeoCode))
            {
                return await CreateWithDependant(entity);
            }
            else if (!entity.IsPrincipal && !string.IsNullOrEmpty(entity.GeoCode))
            {
                return await CreateDependantWithDiferentAddress(entity);
            }
            var mapp = _mapper.Map<MigratoryInformation>(entity);

            return await CreateAsync(mapp);
        }

        public async Task<RequestResult<MigratoryInformationViewModel>> DispatchUpdate(MigratoryInformationViewModel entity)
        {
            if (entity.TaxReturnInfo.Cedula != null)
            {
                entity.TaxReturnInfo.Cedula = entity.TaxReturnInfo.Cedula.Replace("-", "");
                entity.TaxReturnInfo.Telefono = entity.TaxReturnInfo.Telefono.Replace("-", "");
            }

            if (!entity.IsPrincipal && entity.HasCommonAddress)
            {
                return await UpdateWithDependant(entity);
            }
            else if (!entity.IsPrincipal && !entity.HasCommonAddress)
            {
                return await UpdateDependantWithDiferentAddress(entity);
            }
            var mapp = _mapper.Map<MigratoryInformation>(entity);

            return await EditAsync(mapp);
        }

        public async Task<RequestResult<MigratoryInformationViewModel>> CreateWithDependant(MigratoryInformationViewModel entity)
        {
            var reqResult = RequestResult<MigratoryInformationViewModel>.Failed();

            var dependantDidExist = await AnyAsync(x =>
                x.ApplicationId == entity.ApplicationId && x.PassportNumber == entity.PassportNumber && !x.Id.Equals(entity.Id));
            if (dependantDidExist)
            {
                reqResult.SetCode((int)CommonError.RepeatedPassport);
                return reqResult.AddError($@"A person with this passport: {entity.PassportNumber}, already Exist");
            }

            var principal = await GetQueryable(x => x.ApplicationId == entity.ApplicationId && x.IsPrincipal)
                .FirstOrDefaultAsync();
            if (principal != null)
            {
                entity.GeoCode = principal.GeoCode;
                entity.EmbarcationDate = principal.EmbarcationDate;
                entity.EmbarcationFlightNumber = principal.EmbarcationFlightNumber;
                entity.EmbarkationPort = principal.EmbarkationPort;
                entity.DisembarkationPort = principal.DisembarkationPort;
                entity.DisembarkationFligthNumber = principal.DisembarkationFligthNumber;
                entity.TransportationCompany = principal.TransportationCompany;
                entity.OriginFlightDate = principal.OriginFlightDate;
                entity.OriginFlightNumber = principal.OriginFlightNumber;
                entity.OriginPort = principal.OriginPort;
                if (entity.HasCommonHotel) entity.HotelId = principal.HotelId;
                var mapp = _mapper.Map<MigratoryInformation>(entity);

                return await CreateAsync(mapp);
            }
            return reqResult;
        }



        public async Task<RequestResult<MigratoryInformationViewModel>> UpdateWithDependant(MigratoryInformationViewModel entity)
        {
            var reqResult = RequestResult<MigratoryInformationViewModel>.Failed();

            if (entity.HasCommonAddress)
            {
                var dependantDidExist = await AnyAsync(x =>
                    x.ApplicationId == entity.ApplicationId && x.PassportNumber == entity.PassportNumber && !x.Id.Equals(entity.Id));
                if (dependantDidExist)
                {
                    reqResult.SetCode((int)CommonError.RepeatedPassport);
                    return reqResult.AddError($@"A person with this passport: {entity.PassportNumber}, already Exist");
                }

                var principal = await GetQueryable(x => x.ApplicationId == entity.ApplicationId && x.IsPrincipal)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                if (principal != null)
                {
                    entity.GeoCode = principal.GeoCode;
                    entity.EmbarcationDate = principal.EmbarcationDate;
                    entity.EmbarcationFlightNumber = principal.EmbarcationFlightNumber;
                    entity.EmbarkationPort = principal.EmbarkationPort;
                    entity.DisembarkationPort = principal.DisembarkationPort;
                    entity.DisembarkationFligthNumber = principal.DisembarkationFligthNumber;
                    entity.TransportationCompany = principal.TransportationCompany;
                    entity.OriginFlightDate = principal.OriginFlightDate;
                    entity.OriginFlightNumber = principal.OriginFlightNumber;
                    entity.OriginPort = principal.OriginPort;
                    entity.Street = principal.Street;
                    if (entity.HasCommonHotel) entity.HotelId = principal.HotelId;
                    var mapp = _mapper.Map<MigratoryInformation>(entity);
                    return await EditAsync(mapp);
                }
                return reqResult;
            }
            return reqResult;
        }

        public async Task<RequestResult<MigratoryInformationViewModel>> UpdateDependantWithDiferentAddress(MigratoryInformationViewModel entity)
        {
            var reqResult = RequestResult<MigratoryInformationViewModel>.Failed();

            if (!entity.HasCommonAddress)
            {
                var dependantDidExist = await AnyAsync(x =>
                    x.ApplicationId == entity.ApplicationId && x.PassportNumber == entity.PassportNumber && !x.Id.Equals(entity.Id));
                if (dependantDidExist)
                {
                    reqResult.SetCode((int)CommonError.RepeatedPassport);
                    return reqResult.AddError($@"A person with this passport: {entity.PassportNumber}, already Exist");
                }

                var mapp = _mapper.Map<MigratoryInformation>(entity);
                return await EditAsync(mapp);
            }
            return reqResult;
        }

        public async Task<RequestResult<MigratoryInfoToCustoms>> GetByApplicationIdAndCustoms(int applicationId)
        {
            var reqResult = RequestResult<MigratoryInfoToCustoms>.Failed();
            var list = await GetQueryable(x => x.ApplicationId == applicationId)
                .Include(x => x.Application)
                .ThenInclude(x => x.GenericInformation)
                .Include(x => x.CustomsInformation)
                    .ThenInclude(x => x.DeclaredMerchs)
                .ToListAsync();
            var mapped = _mapper.Map<List<MigratoryInformationViewModel>>(list);
            var vm = new MigratoryInfoToCustoms();
            mapped.ForEach(x =>
            {
                if (x.CustomsInformation != null)
                {
                    if (x.CustomsInformation.Ammount.HasValue) x.CustomsInformation.Ammount = Decimal.Truncate(x.CustomsInformation.Ammount.Value);
                    x.CustomsInformation.IsUnderAge = x.BirthDate.GetAge() < (int)AgeEnum.Adult;
                }
                else
                {
                    x.CustomsInformation = new CustomsInformationWiewModel { IsUnderAge = x.BirthDate.GetAge() < (int)AgeEnum.Adult };
                }
            });
            vm.MigratoryInformation = mapped;
            if (list.Any())
            {
                vm.Companions = list.Select(x => x.Application.Companions).FirstOrDefault();
                vm.TotalCreated = list.Count;
                reqResult.SetSucceeded(vm);
                return reqResult;
            }
            return reqResult;
        }

        public async Task<RequestResult<MigratoryInformationViewModel>> CreateDependantWithDiferentAddress(MigratoryInformationViewModel entity)
        {
            var reqResult = RequestResult<MigratoryInformationViewModel>.Failed();

            var dependantDidExist = await AnyAsync(x =>
                 x.ApplicationId == entity.ApplicationId && x.PassportNumber == entity.PassportNumber);
            if (dependantDidExist)
            {
                reqResult.SetCode((int)CommonError.RepeatedPassport);
                return reqResult.AddError($@"A person with this passport: {entity.PassportNumber}, already Exist");
            }
            var principal = await GetQueryable(x => x.ApplicationId == entity.ApplicationId && x.IsPrincipal)
                .FirstOrDefaultAsync();
            if (principal != null)
            {
                entity.EmbarcationDate = principal.EmbarcationDate;
                entity.EmbarcationFlightNumber = principal.EmbarcationFlightNumber;
                entity.EmbarkationPort = principal.EmbarkationPort;
                entity.DisembarkationPort = principal.DisembarkationPort;
                entity.DisembarkationFligthNumber = principal.DisembarkationFligthNumber;
                entity.TransportationCompany = principal.TransportationCompany;
                entity.OriginFlightDate = principal.OriginFlightDate;
                entity.OriginFlightNumber = principal.OriginFlightNumber;
                entity.OriginPort = principal.OriginPort;
                if (entity.HasCommonHotel) entity.HotelId = principal.HotelId;
                var mapp = _mapper.Map<MigratoryInformation>(entity);

                return await CreateAsync(mapp);
            }
            return reqResult;
        }

        public async Task<RequestResult<MigratoryInformationToPublicHealth>> GetByApplicationIdAndPublicHealth(int applicationId)
        {
            var reqResult = RequestResult<MigratoryInformationToPublicHealth>.Failed();
            var list = await GetQueryable(x => x.ApplicationId == applicationId)
                .Include(x => x.Application)
                    .ThenInclude(x => x.GenericInformation)
                .Include(x => x.PublicHealth)
                    .ThenInclude(x => x.PublicHealthCountries)
                        .ThenInclude(x => x.Country)
                .Include(x => x.PublicHealth)
                    .ThenInclude(x => x.PublicHealthStopOvers)
                        .ThenInclude(x => x.Country)
                .Include(x => x.PublicHealth)
                    .ThenInclude(x => x.QuestionResponse)
                        .ThenInclude(x => x.Question)
                .ToListAsync();

            if (list.Any())
            {
                var mapped = _mapper.Map<List<MigratoryInformationViewModel>>(list);
                mapped.ForEach(x =>
                    {
                        x.PublicHealth.IsValid = _publicHealthValidatorService.IsPublicHealthViewModelValid(x.PublicHealth);
                    });

                var modelToPh = new MigratoryInformationToPublicHealth
                {
                    MigratoryInformation = mapped,
                    TotalCreated = mapped.Count,
                    Companions = mapped.Select(x => x.Application.Companions).FirstOrDefault()
                };
                return reqResult.SetSucceeded(modelToPh);
            }

            return reqResult.AddError("Error Fetching Information");
        }

        public async Task<RequestResult<IEnumerable<MigratoryInformationViewModel>>> GetToPostDga(OutputParams outputParams)
        {
            var reqResult = RequestResult<IEnumerable<MigratoryInformationViewModel>>.Failed();
            var list = await GetQueryable(x => x.ApplicationId == outputParams.ApplicationId)
                .Include(x => x.Application)
                    .ThenInclude(x => x.GenericInformation)
                .Include(x => x.Airline)
                .Include(x => x.FlightMotive)
                .Include(x => x.Ocupation)
                .ToListAsync();
            if (list.Any())
            {
                var mapped = _mapper.Map<List<MigratoryInformationViewModel>>(list);
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }
            return reqResult;
        }

        public async Task<List<MigratoryInformationViewModel>> GetAllMigratoryInformationsByAppId(int appId)
        {
            var reqResult = RequestResult<List<MigratoryInformationViewModel>>.Failed();
            var list = await GetQueryable(x => x.ApplicationId == appId)
               .Include(x => x.Application)
               .Include(x => x.TaxReturnInfo)
                .ToListAsync();

            var mapped = _mapper.Map<List<MigratoryInformationViewModel>>(list);
            //TODO: Set this
            if (list.Any())
            {
                reqResult.SetSucceeded(mapped);
                return reqResult.Payload;
            }
            reqResult.SetSucceeded(mapped);
            return reqResult.Payload;
        }

        public async Task<RequestResult<bool>> IsReadyToDga(int applicationId, int totalCompanions)
        {
            var reqResult = RequestResult<bool>.Failed();
            int totalCreated = await GetQueryable(x => x.ApplicationId == applicationId).CountAsync();

            if (totalCreated == totalCompanions + 1)
                return reqResult.SetSucceeded(true);
            return reqResult;

        }

        public MigratoryInformation MapToModel(MigratoryInformationViewModel migratoryInformation)
        {
            return _mapper.Map<MigratoryInformation>(migratoryInformation);
        }
    }
}
