using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Hotels
{
    public class Hotel : BaseModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SocialReason { get; set; }
        public string Coordinates { get; set; }
        public string GeoCode { get; set; }
    }
}