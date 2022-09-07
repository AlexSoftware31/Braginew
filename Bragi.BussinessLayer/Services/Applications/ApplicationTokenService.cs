using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.ViewModels.Applications;
using Microsoft.EntityFrameworkCore;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.Applications
{
    public class ApplicationTokenService : BaseService<ApplicationToken, ProyectDbContext, ApplicationTokenViewModel>, IApplicationTokenService
    {
        private readonly IMapper _mapper;
        public ApplicationTokenService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<RequestResult<ApplicationTokenViewModel>> GetByToken(string token)
        {
            var result = await GetQueryable(x => x.Token == token).Include(x => x.Application)
                .FirstOrDefaultAsync();
            var mapped = _mapper.Map<ApplicationTokenViewModel>(result);
            if (result != null) return RequestResult<ApplicationTokenViewModel>.Success(mapped);
            return RequestResult<ApplicationTokenViewModel>.Failed();
        }
    }
}
