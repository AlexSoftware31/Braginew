using System.ComponentModel.DataAnnotations.Schema;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Cities;
using Bragi.DataLayer.ViewModels.Core;
using Bragi.DataLayer.ViewModels.Transportation;

namespace Bragi.DataLayer.ViewModels.GenericInformations
{
    public class GenericInformationViewModel : BaseViewModel
    {
        public string PermanentResidenceAdress { get; set; }
        public string CityOfResidence { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CountryResidence { get; set; }
        public int Companions { get; set; }
        public bool WillStayAtResort { get; set; }
        public bool StopOverInCountries { get; set; }
        public int ApplicationId { get; set; }
        public virtual ApplicationViewModel Application { get; set; }
        public bool IsArrival { get; set; }
        public int TransportationMethodId { get; set; }
        public virtual TransportationMethodViewModel TransportationMethod { get; set; }
        public int? CityId { get; set; }
        public CityViewModel City { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }

}