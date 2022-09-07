using Bragi.DataLayer.ViewModels.Core;
using Bragi.DataLayer.ViewModels.Countries;

namespace Bragi.DataLayer.ViewModels.PublicHealths
{
    public class PublicHealthCountriesViewModel : BaseViewModel
    {
        public int CountryId { get; set; }
        public int PublicHealthId { get; set; }
        public CountryViewModel Country { get; set; }
        public PublicHealthViewModel PublicHealth { get; set; }
    }
}
