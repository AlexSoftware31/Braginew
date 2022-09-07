using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Cities
{
    public class CityViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Iso2CountryCode { get; set; }
        public string State { get; set; }
    }
}
