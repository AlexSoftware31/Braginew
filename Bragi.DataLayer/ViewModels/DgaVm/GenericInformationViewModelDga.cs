using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.ViewModels.Transportation;

namespace Bragi.DataLayer.ViewModels.DgaVm
{
    public class GenericInformationViewModelDga
    {
        public int ApplicationId { get; set; }
        public string PermanentResidenceAdress { get; set; }
        public string CityOfResidence { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CountryResidence { get; set; }
        public int Companions { get; set; }
        public bool WillStayAtResort { get; set; }
        public bool StopOverInCountries { get; set; }
        public bool IsArrival { get; set; }
        public int TransportationMethodId { get; set; }
        public virtual TransportationMethodViewModel TransportationMethod { get; set; }
    }
}
