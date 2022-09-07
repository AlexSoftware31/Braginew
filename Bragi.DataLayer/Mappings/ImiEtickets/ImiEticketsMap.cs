using AutoMapper;
using Bragi.DataLayer.Models.ImiEtickets;
using Bragi.DataLayer.ViewModels.ImiEtickets;

namespace Bragi.DataLayer.Mappings.ImiEtickets
{
    public class ImiEticketsMap : Profile
    {
        public ImiEticketsMap()
        {
            CreateMap<T01_Etickets, T01_EticketsViewModel>();
        }
    }
}
