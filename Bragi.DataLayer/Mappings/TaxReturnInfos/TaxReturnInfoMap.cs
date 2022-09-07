using AutoMapper;
using Bragi.DataLayer.Models.TaxReturnInfos;
using Bragi.DataLayer.ViewModels.TaxReturnInfos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.Mappings.TaxReturnInfos
{
    public class TaxReturnInfoMap : Profile
    {
        public TaxReturnInfoMap()
        {
            CreateMap<TaxReturnInfo, TaxReturnInfoViewModel>().ReverseMap();
        }
    }
}
