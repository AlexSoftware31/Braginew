using AutoMapper;
using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.ViewModels.Airlines;

namespace Bragi.DataLayer.Mappings.Airlines
{
    public class AirlinesMap : Profile
    {
        public AirlinesMap()
        {
            CreateMap<Airline, AirlineViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Code} - {src.Name}")); 
        }
    }
}
