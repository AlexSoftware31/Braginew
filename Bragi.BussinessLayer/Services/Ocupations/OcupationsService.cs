using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Ocupations;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Ocupations;
using Bragi.DataLayer.ViewModels.Ocupations;

namespace Bragi.BussinessLayer.Services.Ocupations
{
    public class OcupationsService : LangBaseService<Ocupation, ProyectDbContext, OcupationViewModel>, IOcupationsService
    {
        public OcupationsService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
