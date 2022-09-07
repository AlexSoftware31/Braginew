using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Customs
{
    public class DeclaredMerch : BaseModel
    {
        public int  CustomsInformationId { get; set; }
        public string Description { get; set; }
        public decimal DollarValue { get; set; }
        public virtual CustomsInformation CustomsInformation { get; set; }
    }
}
