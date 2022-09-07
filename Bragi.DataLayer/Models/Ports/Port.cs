using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Transportation;

namespace Bragi.DataLayer.Models.Ports
{
    public class Port : BaseModel
    {
        public string InspectionCode { get; set; }
        public string Code { get; set; }
        public int? TransportationMethodId { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public bool IsDominicanPort { get; set; }
        public virtual TransportationMethod TrasTransportationMethod { get; set; }
    }
}
