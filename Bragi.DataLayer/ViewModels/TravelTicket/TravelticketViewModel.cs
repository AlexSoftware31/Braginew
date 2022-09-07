using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Jwt;

namespace Bragi.DataLayer.ViewModels.TravelTicket
{
    public class TravelticketViewModel
    {
        public ApplicationViewModel Application { get; set; }
        public JwtViewModel JwtViewModel { get; set; }
    }
}
