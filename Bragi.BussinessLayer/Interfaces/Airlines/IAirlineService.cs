using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.ViewModels.Airlines;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Airlines
{
    public interface IAirlineService: IRepository<Airline,AirlineViewModel>, IBaseInterface<Airline, AirlineViewModel>
    {
    }
}