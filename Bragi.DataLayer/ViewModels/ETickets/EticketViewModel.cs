using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.ViewModels.Applications;

namespace Bragi.DataLayer.ViewModels.ETickets
{
    public class EticketViewModel : BaseModel
    {
        public string PrincipalName { get; set; }
        public string Passport { get; set; }
        public string InOut { get; set; }
        public string Nationality { get; set; }
        public string Sequence { get; set; }
        public int ApplicationId { get; set; }
        public ApplicationViewModel Application { get; set; }
    }
}
