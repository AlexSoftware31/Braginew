using AutoMapper;
using Bragi.DataLayer.Models.Ports;
using Bragi.DataLayer.ViewModels.Ports;

namespace Bragi.DataLayer.Mappings.Ports
{
    public class PortsMap : Profile
    {
        public PortsMap()
        {
            CreateMap<Port, PortViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Code} - {src.Name}"));
            CreateMap<Port, PortQuery>()
                .ForMember(d => d.Value, o => o.MapFrom(s => s != null ? s.Name :""))              
                .ForMember(x => x.Data, o => o.MapFrom(s => s != null ? s.Name : ""));
        }
    }
}
