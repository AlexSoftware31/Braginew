using AutoMapper;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.DgaVm;
using Bragi.DataLayer.ViewModels.GenericInformations;

namespace Bragi.DataLayer.Mappings.PersonalInformation
{
    public class PersonalInformationMap : Profile
    {
        public PersonalInformationMap()
        {
            CreateMap<GenericInformation, GenericInformationViewModel>().ReverseMap();
            CreateMap<GenericInformation, GenericInformationViewModelDga>();
            CreateMap<MaritalStatus, MaritalStatusViewModel>();
        }
    }
}