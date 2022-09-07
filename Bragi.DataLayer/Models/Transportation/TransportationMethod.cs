using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.DataLayer.Models.Transportation
{
    public class TransportationMethod : BaseModel, ILanguage
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