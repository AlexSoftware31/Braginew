using AutoMapper;
using Bragi.DataLayer.Models.Cities;
using Bragi.DataLayer.ViewModels.Cities;

namespace Bragi.DataLayer.Mappings.Cities
{
    public class CityMap : Profile
    {
        public CityMap()
        {
            CreateMap<City, CityViewModel>();
        }
    }
}
