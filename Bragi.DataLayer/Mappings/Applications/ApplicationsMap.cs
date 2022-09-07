using AutoMapper;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.DgaVm;

namespace Bragi.DataLayer.Mappings.Applications
{
    public class ApplicationsMap : Profile
    {
        public ApplicationsMap()
        {
            CreateMap<Application, ApplicationViewModel>().ReverseMap();
            CreateMap<ApplicationToken, ApplicationTokenViewModel>();
            CreateMap<Application, DgaOutputViewModel>().ForMember(dest => dest.ApplicationId, opt=> opt.MapFrom(src => src.Id));
        }
    }
}