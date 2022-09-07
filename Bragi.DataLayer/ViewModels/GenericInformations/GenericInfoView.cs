using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.Cities;
using Bragi.DataLayer.ViewModels.Countries;
using System.Collections.Generic;

namespace Bragi.DataLayer.ViewModels.GenericInformations
{
    public class GenericInfoView
    {
        public GenericInformation GenericInformation { get; set; }
        public IEnumerable<CountryViewModel> Country { get; set; }
        public IEnumerable<CityViewModel> City { get; set; }
    }
}
