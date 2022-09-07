using AutoMapper;
using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.BussinessLayer.Interfaces.Imi;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.ETickets;
using Bragi.DataLayer.Models.ImiEtickets;
using Bragi.DataLayer.Utils;
using Bragi.DataLayer.ViewModels.ETickets;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NetCoreUtilities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.MigratoryInfo;

namespace Bragi.BussinessLayer.Services.ETickets
{
    public class ETicketService : BaseService<Eticket, ProyectDbContext, EticketViewModel>, IEticketsService
    {
        private readonly IMigratoryInfoService _migratoryInfo;
        private readonly IGenericInformationService _genericInformation;
        private readonly IMapper _mapper;
        private readonly IimiEticketService _imiEticketService;
        private readonly ProyectDbContext _ctx;
        public ETicketService(ProyectDbContext context, IMapper mapper
            , IGenericInformationService genericInformation
            , IMigratoryInfoService migratoryInfoService
            , IimiEticketService eticketService) : base(context, mapper)
        {
            _migratoryInfo = migratoryInfoService;
            _genericInformation = genericInformation;
            _mapper = mapper;
            _imiEticketService = eticketService;
            _ctx = context;
        }


        public async Task<RequestResult<EticketViewModel>> PrepareAndCreate(int applicationId)
        {
            var reqResult = RequestResult<EticketViewModel>.Failed();
            var eticketExist = await AnyAsync(x => x.ApplicationId == applicationId);
            if (eticketExist) return reqResult.SetSucceeded(new EticketViewModel()); //if exist dont insert it again

            if (applicationId == 0) return reqResult;
            var generic = await _genericInformation.FindBy(x => x.ApplicationId == applicationId).FirstOrDefaultAsync();
            if (generic == null) return reqResult;

            var migratoryInfo = await _migratoryInfo
                .GetQueryable(x => x.ApplicationId == applicationId && x.IsPrincipal)
                .FirstOrDefaultAsync();

            if (migratoryInfo == null) return reqResult;

            var emission = new Eticket
            {
                PrincipalName = $"{migratoryInfo.Names} {migratoryInfo.LastNames}",
                Nationality = migratoryInfo.Nationality,
                Passport = migratoryInfo.PassportNumber,
                InOut = generic.IsArrival ? "Arrival" : "Departure",
                ApplicationId = applicationId,
                Sequence = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now
            };
            return await CreateAsync(emission);
        }

        public async Task<RequestResult<EticketViewModel>> GetByApplicationId(int applicationId)
        {
            var eticket = await GetBy(x => x.ApplicationId == applicationId);
            if (eticket != null) return RequestResult<EticketViewModel>.Success(eticket);
            return RequestResult<EticketViewModel>.Failed();
        }

        public async Task<RequestResult<EticketViewModel>> GetByApplicationIdInclude(int applicationId)
        {
            var eticket = await _ctx.Etickets.Where(x => x.ApplicationId.Equals(applicationId))
                .Include(ticket => ticket.Application)
                .ThenInclude(app => app.MigratoryInformations)
                .Select(x => new Eticket
                {
                    InOut = x.InOut,
                    PrincipalName = x.PrincipalName,
                    Passport = x.Passport,
                    Nationality = x.Nationality,
                    Sequence = x.Sequence,
                    CreationDate = x.CreationDate,
                    Application = new Application
                    {
                        Id = x.Application.Id,
                        MigratoryInformations = x.Application.MigratoryInformations.Where(mig => !mig.IsPrincipal).Select(m => new MigratoryInformation
                        {
                            Names = m.Names,
                            LastNames = m.LastNames,
                            PassportNumber = m.PassportNumber,
                            Nationality = m.Nationality
                        })
                    }
                })
                .SingleOrDefaultAsync();

            if (eticket != null)
            {
                return RequestResult<EticketViewModel>.Success(_mapper.Map<EticketViewModel>(eticket));
            }
            return RequestResult<EticketViewModel>.Failed();
        }

        public async Task<RequestResult<EticketViewModel>> GetBySequenceQrCode(string sequenceQrCode)
        {
            var reqResult = RequestResult<EticketViewModel>.Failed();
            var info = await GetBy(x => x.Sequence == sequenceQrCode);
            if (info != null)
            {
                return reqResult.SetSucceeded(info);
            }
            return reqResult;
        }

        public async Task<RequestResult<MigratoryInfoAirlineViewModel>> GetMigratoryInfoToAirlinesCheckin(string qrCode)
        {
            var reqResult = RequestResult<MigratoryInfoAirlineViewModel>.Failed();
            var eticket = await GetBySequenceQrCode(qrCode);
            if (eticket.IsSuccessfulWithNoErrors)
            {
                var migratoryInfo = await _migratoryInfo.GetList(x => x.ApplicationId == eticket.Payload.ApplicationId);
                if (migratoryInfo != null)
                {
                    var result = new MigratoryInfoAirlineViewModel
                    {
                        Eticket = eticket.Payload,
                        MigratoryInformationViewModels = _mapper.Map<List<MigratoryInformationViewModel>>(migratoryInfo)
                    };
                    return reqResult.SetSucceeded(result);
                }
                return reqResult;
            }
            return reqResult;
        }

        public async Task<RequestResult> SavePassengersIntoImi(int applicationId)
        {
            var reqResult = RequestResult.Failed();
            var didExistOnImi = await _imiEticketService.AnyAsync(x => x.ApplicationId == applicationId);
            if (didExistOnImi) return RequestResult.Success(); //if already exist on imi dont insert. 


            var passengerInfo = await _migratoryInfo.GetInformationByApplicationId(applicationId);
            IDbContextTransaction m = _ctx.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
            if (passengerInfo.Payload != null)
            {
                passengerInfo.Payload.ForEach(async x =>
                {
                    var mappedValues = _mapper.Map<T01_Etickets>(x);
                    mappedValues = mappedValues.ToUpper();
                    mappedValues.ApplicationId = applicationId;
                    //x.Nationality = x.Nationality.ToUpperOrEmpty();
                    mappedValues.EntradaSalida = x.Application.GenericInformation.IsArrival ? "E" : "S";
                    await _imiEticketService.AddAsync(mappedValues);
                });
                reqResult = await _imiEticketService.CommitAsync(m);
                return reqResult;
            }
            return reqResult;
        }
    }
}
