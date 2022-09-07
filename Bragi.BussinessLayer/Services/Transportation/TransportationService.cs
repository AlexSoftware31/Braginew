using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Transportation;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Transportation;
using Bragi.DataLayer.ViewModels.Transportation;

namespace Bragi.BussinessLayer.Services.Transportation
{
    public class TransportationService : LangBaseService<TransportationMethod, ProyectDbContext, TransportationMethodViewModel>, ITransportationService
    {
        public TransportationService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}