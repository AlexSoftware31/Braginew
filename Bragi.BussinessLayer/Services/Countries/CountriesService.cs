using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Countries;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.ViewModels.Countries;

namespace Bragi.BussinessLayer.Services.Countries
{
    public class CountriesService : BaseService<Country, ProyectDbContext, CountryViewModel>, ICountriesService
    {
        public CountriesService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
