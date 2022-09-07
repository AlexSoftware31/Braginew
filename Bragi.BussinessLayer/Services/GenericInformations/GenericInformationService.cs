using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Services.GenericInformations
{
    public class GenericInformationService : BaseService<GenericInformation, ProyectDbContext, GenericInformationViewModel>, IGenericInformationService
    {

        private readonly IMapper _mapper;
        private readonly IApplicationTokenService _appToken;

        public GenericInformationService(ProyectDbContext context, IMapper mapper, IApplicationTokenService appToken) : base(context, mapper)
        {
            _mapper = mapper;
            _appToken = appToken;
        }


        public async Task<RequestResult<GenericInformationViewModel>> GetByApplicationId(int applicationId)
        {
            var reqResult = RequestResult<GenericInformationViewModel>.Failed();
            var result = await GetQueryable(x => x.ApplicationId == applicationId)
                .Include(x => x.Application)
                .Include(x => x.City)
                //.ProjectTo<GenericInformationViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<GenericInformationViewModel>(result);
            if (mapped != null)
            {
                reqResult.SetSucceeded(mapped);
                return reqResult;
            }

            return reqResult;
        }

        public async Task<RequestResult<GenericInformationViewModel>> GetByAccessToken(string token)
        {
            var reqResult = RequestResult<GenericInformationViewModel>.Failed();
            var app = await _appToken.GetByToken(token);
            if (app.IsSuccessfulWithNoErrors)
            {
                var getGi = await GetQueryable(x => x.ApplicationId == app.Payload.ApplicationId)
                    .Include(x => x.Application)
                    .Include(x => x.City)
                    .FirstOrDefaultAsync();
                var mapped = _mapper.Map<GenericInformationViewModel>(getGi);
                return reqResult.SetSucceeded(mapped);
            }
            return reqResult;
        }

        public async Task<RequestResult<GenericInformationViewModel>> CreateOrUpdate(GenericInformationViewModel genericInformation)
        {
            var gi = await AnyAsync(x => x.Id == genericInformation.Id);
            var mappedGi = _mapper.Map<GenericInformation>(genericInformation);
            if (gi)
            {
                return await EditAsync(mappedGi);
            }
            return await CreateAsync(mappedGi);
        }

    }
}
