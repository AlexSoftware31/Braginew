using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Microsoft.EntityFrameworkCore;

namespace Bragi.BussinessLayer.Services.GeoCodes
{
    public class MunicipalityService : BaseService<Municipality, ProyectDbContext, MunicipalityViewModel>, IMunicipalityService
    {
        private readonly IMapper _mapper;
        public MunicipalityService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<MunicipalityViewModel>> GetAllMunicipalitiesByProvinceCode(string provinceCode)
        {
            var result = await GetQueryable(x => x.Province == provinceCode)
                   .OrderBy(x => x.ToponomyName).ToListAsync();
            return _mapper.Map<List<MunicipalityViewModel>>(result);
        }
    }
}