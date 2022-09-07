using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Hotels;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.ViewModels.Hotels;

namespace Bragi.BussinessLayer.Services.Hotels
{
    public class HotelService : BaseService<Hotel, ProyectDbContext, HotelViewModel>, IHotelService
    {
        public HotelService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
