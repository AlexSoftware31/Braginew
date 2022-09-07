using AutoMapper;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;

namespace Bragi.DataLayer.Mappings.PublicHealths
{
    public class PublicHeathMap : Profile
    {
        public PublicHeathMap()
        {
            CreateMap<PublicHealth, PublicHealthViewModel>().ReverseMap();
            CreateMap<PublicHealthStopOver, PublicHealthStopOverViewModel>().ReverseMap();            
            CreateMap<PublicHealthCountries, PublicHealthCountriesViewModel>().ReverseMap();
        }
    }
}
