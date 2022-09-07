using AutoMapper;
using Bragi.DataLayer.Models.Ocupations;
using Bragi.DataLayer.ViewModels.Ocupations;

namespace Bragi.DataLayer.Mappings.Ocupations
{
    public class OcupationsMap : Profile
    {
        public OcupationsMap()
        {
            CreateMap<Ocupation, OcupationViewModel>();
        }
    }
}