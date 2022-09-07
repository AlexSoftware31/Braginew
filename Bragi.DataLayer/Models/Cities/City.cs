using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Cities
{
    public class City : BaseModel
    {
        public string Name { get; set; }
        public string StateCode { get; set; }
        public string Iso2CountryCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
    }
}
