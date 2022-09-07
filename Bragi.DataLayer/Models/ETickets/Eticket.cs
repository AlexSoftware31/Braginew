using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.ETickets
{
    public class Eticket : BaseModel
    {
        public string PrincipalName { get; set; }
        public string  Passport { get; set; }
        public string InOut { get; set; }
        public string  Nationality { get; set; }
        public string  Sequence { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
