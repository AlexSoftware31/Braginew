using AutoMapper;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.ViewModels.Hotels;

namespace Bragi.DataLayer.Mappings.Hotels
{
    public class HotelMap : Profile
    {
        public HotelMap()
        {
            CreateMap<Hotel, HotelViewModel>();
        }
    }
}