using System.ComponentModel.DataAnnotations;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.MigratoryInfo;

namespace Bragi.DataLayer.Models.GeoCodes
{
    public class Sectors : BaseModel
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