using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.ViewModels.Hotels;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Hotels
{
    public interface IHotelService : IRepository<Hotel, HotelViewModel>, IBaseInterface<Hotel,HotelViewModel>
    {
    }
}