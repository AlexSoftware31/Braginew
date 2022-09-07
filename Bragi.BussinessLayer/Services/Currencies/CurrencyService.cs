using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Currencies;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.ViewModels.Currencies;

namespace Bragi.BussinessLayer.Services.Currencies
{
    public class CurrencyService : BaseService<Currency,ProyectDbContext,CurrencyViewModel>, ICurrencyService
    {
        public CurrencyService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}