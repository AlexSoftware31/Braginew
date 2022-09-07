using Bragi.DataLayer.ViewModels.Airlines;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Core;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.FlightMotives;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Bragi.DataLayer.ViewModels.Hotels;
using Bragi.DataLayer.ViewModels.Ocupations;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.DataLayer.ViewModels.TaxReturnInfos;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bragi.DataLayer.ViewModels.MigratoryInfo
{
    public class MigratoryInformationViewModel : BaseViewModel
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public string BirthPlace { get; set; }
        public string PassportNumber { get; set; }
        public string PassportConfirmation { get; set; }
        public string DocumentIdNumber { get; set; }
        public string GeoCode { get; set; }
        public string Street { get; set; }
        public int MaritalStatusId { get; set; }
        public int FlightMotiveId { get; set; }
        public int ApplicationId { get; set; }
        public int? HotelId { get; set; }
        public int OcupationId { get; set; }
        public int? AirlineId { get; set; }
        public int? EmbarkationPortNavId { get; set; }
        public int? DisembarkationPortNavId { get; set; }
        public int? OriginPortNavId { get; set; }
        public string OriginPort { get; set; }
        public string OriginFlightNumber { get; set; }
        public DateTime? OriginFlightDate { get; set; }
        public string EmbarkationPort { get; set; }
        public string EmbarcationFlightNumber { get; set; }
        public string DisembarkationFligthNumber { get; set; }
        public DateTime? EmbarcationDate { get; set; }
        public string DisembarkationPort { get; set; }
        public string DisembarkationPortFligthNumber { get; set; }
        public string TransportationCompany { get; set; }
        public int DaysOfStaying { get; set; }
        public string SpecificFlightMotive { get; set; }
        public bool IsPrincipal { get; set; }
        public bool HasCommonAddress { get; set; }
        public bool IsParticularStaying { get; set; }
        public bool HasCommonHotel { get; set; }
        public bool WillStayAtResort { get; set; }
        public string ConfirmationNumber { get; set; }
        public string Email { get; set; }
        public bool IsResident { get; set; }
        public string ResidenceNumber { get; set; }
        public virtual FlightMotiveViewModel FlightMotive { get; set; }
        //public virtual ApplicationViewModel Application { get; set; } //TODO Check if this is necesary in ViewModel
        public CustomsInformationWiewModel CustomsInformation { get; set; }
        public HotelViewModel Hotel { get; set; }
        public virtual OcupationViewModel Ocupation { get; set; }
        public PublicHealthViewModel PublicHealth { get; set; }
        public virtual MaritalStatusViewModel MaritalStatus { get; set; }
        public virtual SectorsViewModel Sector { get; set; }
        public virtual ApplicationViewModel Application { get; set; }
        public virtual AirlineViewModel Airline { get; set; }
        public TaxReturnInfoViewModel TaxReturnInfo { get; set; }

        [NotMapped]
        public int PersonIndex { get; set; }
        [NotMapped]
        public bool StopOverInCountries { get; set; }
        [NotMapped]
        public bool IsArrival { get; set; }
        [NotMapped]
        public bool IsTaxReturnInfo { get; set; }

        [NotMapped] public string FullName => $"{Names} {LastNames}";
    }

   
}
