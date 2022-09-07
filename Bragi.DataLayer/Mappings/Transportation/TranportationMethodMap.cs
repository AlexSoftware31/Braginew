using AutoMapper;
using Bragi.DataLayer.Models.Transportation;
using Bragi.DataLayer.ViewModels.Transportation;

namespace Bragi.DataLayer.Mappings.Transportation
{
    public class TranportationMethodMap : Profile
    {
        public TranportationMethodMap()
        {
            CreateMap<TransportationMethod, TransportationMethodViewModel>();
        }
    }
}