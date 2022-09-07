using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.ViewModels.Airlines;
using Bragi.DataLayer.ViewModels.Countries;
using Bragi.DataLayer.ViewModels.FlightMotives;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Bragi.DataLayer.ViewModels.Ocupations;
using Bragi.DataLayer.ViewModels.Ports;
using System.Collections.Generic;
using Bragi.DataLayer.ViewModels.Hotels;

namespace Bragi.DataLayer.ViewModels.MigratoryInfo
{
    public class MigratoryInfoView
    {
        public GenericInformationViewModel GenericInformation { get; set; }
        public MigratoryInformationViewModel MigratoryInformation { get; set; }
        public List<CountryViewModel> Countries { get; set; }
        public List<PortViewModel> Ports { get; set; }
        public List<MaritalStatusViewModel> MaritalStatus { get; set; }
        public List<OcupationViewModel> Ocupation { get; set; }
        public List<ProvincesViewModel> Provinces { get; set; }
        public List<MunicipalityViewModel> Municipality { get; set; }
        public List<SectorsViewModel> Sectors { get; set; }
        public List<AirlineViewModel> Airline { get; set; }
        public List<FlightMotiveViewModel> FlightMotives { get; set; }
        public List<HotelViewModel> Hotels { get; set; }
        public bool IsPrincipal { get; set; }
        public int Companions { get; set; }
        public int PersonIndex { get; set; }
        public int TotalCreated { get; set; }
        public string Token { get; set; }
    }


}
