using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Municipality = Bragi.DataLayer.Models.GeoCodes.Municipality;

namespace Bragi.DataLayer.Mappings.GeoLocation
{
    public class GeoLocationMap:Profile
    {
        public GeoLocationMap()
        {
            CreateMap<Provinces, ProvincesViewModel>();
            CreateMap<Municipality, MunicipalityViewModel>();
            CreateMap<Sectors, SectorsViewModel>();
        }
    }
}
