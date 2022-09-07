using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.ViewModels.Countries;

namespace Bragi.DataLayer.ViewModels.PublicHealths
{
    public class PublicHealthStopOverViewModel : BaseModel
    {
        public int CountryId { get; set; }
        public int PublicHealthId { get; set; }
        public CountryViewModel Country { get; set; }
        public PublicHealthViewModel PublicHealth { get; set; }
    }
}
