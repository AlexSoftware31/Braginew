using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.ViewModels.Countries;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Countries
{
    public interface ICountriesService : IRepository<Country, CountryViewModel>, IBaseInterface<Country, CountryViewModel>
    {
    }
}
