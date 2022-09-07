using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.GeoCodes
{
    public interface IProvinceService : IRepository<Provinces,ProvincesViewModel>, IBaseInterface<Provinces, ProvincesViewModel>
    {
        
    }
}