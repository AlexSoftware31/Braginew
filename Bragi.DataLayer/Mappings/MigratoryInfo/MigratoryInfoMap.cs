using AutoMapper;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.Models.ImiEtickets;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.ViewModels.DgaVm;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Bragi.DataLayer.ViewModels.MigratoryInfo;

namespace Bragi.DataLayer.Mappings.MigratoryInfo
{
    public class MigratoryInfoMap : Profile
    {
        public MigratoryInfoMap()
        {
            CreateMap<MigratoryInformation, MigratoryInformationViewModel>()
                .ForMember(dest => dest.Sector, opt => opt.NullSubstitute(new SectorsViewModel()))
                .ReverseMap()
                .ForMember(dest => dest.TaxReturnInfo, opt => opt.Condition((src, dest, member) => { return src.IsTaxReturnInfo && member.Cedula != null && member.Telefono != null; }));

            //.ForMember(dest => dest.Sector, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.GeoCode) ? new Sectors() : src.GeoCode));
            CreateMap<MigratoryInformationViewModel, T01_Etickets>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Names))
                .ForMember(dest => dest.LastNames, opt => opt.MapFrom(src => src.LastNames))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality));
            CreateMap<MigratoryInformation, MigratoryInformationDga>();

        }
    }
}