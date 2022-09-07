using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Agencies;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Agencies;
using Bragi.DataLayer.ViewModels.Agencys;

namespace Bragi.BussinessLayer.Services.Agencies
{
    public class AgencyService : BaseService<Agency, ProyectDbContext, AgencyViewModel>, IAgencyService
    {
        public AgencyService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}