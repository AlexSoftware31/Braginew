using AutoMapper;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.DgaVm;

namespace Bragi.DataLayer.Mappings.Customs
{
    public class CustomsMap : Profile
    {
        public CustomsMap()
        {
            CreateMap<CustomsInformation, CustomsInformationWiewModel>().ReverseMap();
            CreateMap<DeclaredMerch, DeclaredMerchViewModel>().ReverseMap();
            CreateMap<CustomsInformation, CustomsInformationViewModelDga>();
        }
    }
}
