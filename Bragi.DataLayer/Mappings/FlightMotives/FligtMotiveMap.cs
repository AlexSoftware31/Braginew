using AutoMapper;
using Bragi.DataLayer.Models.FlightMotives;
using Bragi.DataLayer.ViewModels.FlightMotives;

namespace Bragi.DataLayer.Mappings.FlightMotives
{
    public class FligtMotiveMap : Profile
    {
        public FligtMotiveMap()
        {
            CreateMap<FlightMotive, FlightMotiveViewModel>();
        }
    }
}