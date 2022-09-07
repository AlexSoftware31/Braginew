using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Countries
{
    public class Country : BaseModel
    {
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public int Zoom { get; set; }
    }
}