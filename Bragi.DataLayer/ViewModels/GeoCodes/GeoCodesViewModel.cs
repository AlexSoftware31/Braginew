using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.ViewModels.GeoCodes
{
    public class GeoCodesViewModel
    {
        public IEnumerable<ProvincesViewModel> Provinces { get; set; }
        public string ProvinceCode { get; set; }
        public IEnumerable<MunicipalityViewModel> Municipalities { get; set; }
        public string MunicipalityCode { get; set; }
        public IEnumerable<SectorsViewModel> Sectors { get; set; }
        public string SectorCode { get; set; }
    }
}
