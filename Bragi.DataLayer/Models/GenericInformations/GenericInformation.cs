using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.Cities;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Transportation;

namespace Bragi.DataLayer.Models.GenericInformations
{
    public class GenericInformation : BaseModel
    {
        public string PermanentResidenceAdress { get; set; }
        public string CityOfResidence { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CountryResidence { get; set; }
        public int Companions { get; set; }
        public bool StopOverInCountries { get; set; }
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        public bool IsArrival { get; set; }
        public int? TransportationMethodId { get; set; }
        public virtual TransportationMethod TransportationMethod { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
    }

}