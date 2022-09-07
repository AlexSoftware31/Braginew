using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.MigratoryInfo;

namespace Bragi.DataLayer.Models.TaxReturnInfos
{
    public class TaxReturnInfo : BaseModel
    {
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public int MigratoryInformationId { get; set; }
        public MigratoryInformation MigratoryInformation { get; set; }
    }
}
