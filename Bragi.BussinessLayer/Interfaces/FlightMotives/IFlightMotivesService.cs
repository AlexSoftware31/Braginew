using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.FlightMotives;
using Bragi.DataLayer.ViewModels.FlightMotives;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.FlightMotives
{
    public interface IFlightMotivesService : IRepository<FlightMotive, FlightMotiveViewModel>, IBaseInterface<FlightMotive, FlightMotiveViewModel>,ILangBaseService<FlightMotive, FlightMotiveViewModel>
    {
    }
}
