using System.ComponentModel.DataAnnotations;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.GeoCodes
{
    public class Provinces : BaseModel
    {
        public string GeoCode { get; set; }
        public string MacroRegion { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string ToponomyName { get; set; }
    }
}