using Bragi.DataLayer.ViewModels.Applications;
using System.Collections.Generic;
using Bragi.DataLayer.ViewModels.ETickets;

namespace Bragi.DataLayer.ViewModels.MigratoryInfo
{
    public class MigratoryInfoAirlineViewModel
    {
        public EticketViewModel Eticket { get; set; }
        public List<MigratoryInformationViewModel> MigratoryInformationViewModels { get; set; }
    }
}
