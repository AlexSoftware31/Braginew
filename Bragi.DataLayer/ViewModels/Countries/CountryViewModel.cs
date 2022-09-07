using System.Security.AccessControl;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Countries
{
    public class CountryViewModel : BaseViewModel
    {
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string FullName { get; set; }
    }
}
