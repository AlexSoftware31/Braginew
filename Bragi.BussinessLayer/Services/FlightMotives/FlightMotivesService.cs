using AutoMapper;
using Bragi.BussinessLayer.Interfaces.FlightMotives;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.FlightMotives;
using Bragi.DataLayer.ViewModels.FlightMotives;

namespace Bragi.BussinessLayer.Services.FlightMotives
{
    public class FlightMotivesService : LangBaseService<FlightMotive, ProyectDbContext, FlightMotiveViewModel>, IFlightMotivesService
    {
        public FlightMotivesService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
