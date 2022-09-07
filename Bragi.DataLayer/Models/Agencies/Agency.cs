using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.DataLayer.Models.Agencies
{
    public class Agency : BaseModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public AgenciesEnum  AgencyEnum { get; set; }
    }
}