using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.ViewModels.Currencies;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Currencies
{
    public interface ICurrencyService : IRepository<Currency, CurrencyViewModel>, IBaseInterface<Currency, CurrencyViewModel>
    {

    }
}