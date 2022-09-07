using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.FlightMotives
{
    public class FlightMotive : BaseModel, ILanguage
    {
        public string Spanish { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public string Portuguese { get; set; }
        public string Italian { get; set; }
        public string German { get; set; }
        public string French { get; set; }
    }
}