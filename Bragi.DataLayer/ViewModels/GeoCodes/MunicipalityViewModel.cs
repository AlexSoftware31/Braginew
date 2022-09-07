using System.ComponentModel.DataAnnotations;

namespace Bragi.DataLayer.ViewModels.GeoCodes
{
    public class MunicipalityViewModel
    {
        public string  GeoCode { get; set; }
        public string  MacroRegion { get; set; }
        public string  Region { get; set; }
        public string  Province { get; set; }
        public string  ToponomyName { get; set; }
        public string  Municipalities { get; set; }
    }
}