using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.PublicHealths
{
    public interface IPublicHealthCountriesService : IRepository<PublicHealthCountries, PublicHealthCountriesViewModel>, IBaseInterface<PublicHealthCountries, PublicHealthCountriesViewModel>
    {

    }
}