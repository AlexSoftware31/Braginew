using Bragi.DataLayer.ViewModels.Core;
using Bragi.DataLayer.ViewModels.MigratoryInfo;

namespace Bragi.DataLayer.ViewModels.TaxReturnInfos
{
    public class TaxReturnInfoViewModel 
    {
        public int? Id { get; set; } = null;
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public int MigratoryInformationId { get; set; }
        public MigratoryInformationViewModel MigratoryInformation { get; set; }
    }
}
