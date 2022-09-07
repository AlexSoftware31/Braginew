using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Cities;
using Bragi.DataLayer.ViewModels.Cities;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.Cities
{
    public interface ICitiesService : IRepository<City, CityViewModel>, IBaseInterface<City, CityViewModel>
    {
        Task<IEnumerable<CityViewModel>> GetByIso2(string iso2Code);
        Task<DataCollection<CityViewModel>> GetPagedByCityName(string iso2Country, string name, int pageNumber = 1, int qty = 50);
        Task<IEnumerable<CityViewModel>> GetByCityName(string iso2Country, string name);
    }
}
