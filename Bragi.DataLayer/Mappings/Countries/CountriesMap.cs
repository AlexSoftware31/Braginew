using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.ViewModels.Countries;

namespace Bragi.DataLayer.Mappings.Countries
{
    public class CountriesMap : Profile
    {
        public CountriesMap()
        {
            CreateMap<Country, CountryViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} ({src.Iso3})"));
                
        }
    }
}
