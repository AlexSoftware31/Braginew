using System.ComponentModel.DataAnnotations;

namespace Bragi.DataLayer.ViewModels.GeoCodes
{
    public class SectorsViewModel
    {
        
        public string GeoCode { get; set; }
        public string MacroRegion { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string ToponomyName { get; set; }
        public string Municipalities { get; set; }
        public string MunicipalDistrict { get; set; }
        public string Neighborhood { get; set; }
        public string Section { get; set; }
    }
}