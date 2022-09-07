using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.Models.FlightMotives;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.Models.Ocupations;
using Bragi.DataLayer.Models.Ports;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.Models.TaxReturnInfos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bragi.DataLayer.Models.MigratoryInfo
{
    public class MigratoryInformation : BaseModel
    {
    
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public string BirthPlace { get; set; }
        public string PassportNumber { get; set; }
        public string DocumentIdNumber { get; set; }
        public string GeoCode { get; set; }
        public string Street { get; set; }
        public int MaritalStatusId { get; set; }
        public int? FlightMotiveId { get; set; }
        public int ApplicationId { get; set; }
        public int? HotelId { get; set; }
        public int? OcupationId { get; set; }
        public int? AirlineId { get; set; }
        public int? EmbarkationPortNavId { get; set; }
        public int? DisembarkationPortNavId { get; set; }
        public int? OriginPortNavId { get; set; }
        public int DaysOfStaying { get; set; }
        public string OriginPort { get; set; }
        public string OriginFlightNumber { get; set; }
        public DateTime? OriginFlightDate { get; set; }
        public string EmbarkationPort { get; set; }
        public string EmbarcationFlightNumber { get; set; }
        public DateTime? EmbarcationDate { get; set; }
        public string DisembarkationPort { get; set; }
        public string DisembarkationFligthNumber { get; set; }
        public string TransportationCompany { get; set; }
        public string SpecificFlightMotive { get; set; }
        public bool IsPrincipal { get; set; }
        public bool HasCommonAddress { get; set; }
        public bool HasCommonHotel { get; set; }
        public bool IsParticularStaying { get; set; }
        public bool WillStayAtResort { get; set; }
        public string ConfirmationNumber { get; set; }
        public string Email { get; set; }
        public bool IsResident { get; set; }
        public string ResidenceNumber { get; set; }
        public Hotel Hotel { get; set; }
        public virtual PublicHealth PublicHealth { get; set; }
        public virtual Ocupation Ocupation { get; set; }
        public virtual Application Application { get; set; }
        public virtual CustomsInformation CustomsInformation { get; set; }
        public virtual FlightMotive FlightMotive { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Airline Airline { get; set; }
        public virtual Port OriginPortNav { get; set; }
        public virtual Port DisembarkationPortNav { get; set; }
        public virtual Port EmbarkationPortNav { get; set; }
        public TaxReturnInfo TaxReturnInfo { get; set; }
    }
}
