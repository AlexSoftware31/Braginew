using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using System.Collections.Generic;

namespace Bragi.DataLayer.ViewModels.MigratoryTicket
{
    public class MigratoryTicketViewModel
    {
        public virtual GenericInformationViewModel  GenericInformation { get; set; }
        public virtual List<MigratoryInformationViewModel> MigratoryInformation { get; set; }
    }
}