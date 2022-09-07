using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.Models.MigratoryInfo;
using System.Collections.Generic;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Customs
{
    public class CustomsInformation : BaseModel
    {
        public int ApplicationId { get; set; }
        public int MigratoryInformationId { get; set; }
        public int? CurrencyId { get; set; }
        public bool ExceedsMoneyLimit { get; set; }
        public bool IsValuesOwner { get; set; }
        public bool HasAnimalsOrFood { get; set; }
        public bool HasMerchWithTaxValue { get; set; }
        public string DeclaredOriginValue { get; set; }
        public decimal? Ammount { get; set; }
        public bool IsUnderAge { get; set; }
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverLastName { get; set; }
        public string RelationShip { get; set; }
        public string WorthDestiny { get; set; }
        public int? CurrencyMerchandiseId { get; set; }
        public decimal ValueOfMerchandise { get; set; } = 1;
        public virtual Currency CurrencyMerchandise { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual IEnumerable<DeclaredMerch> DeclaredMerchs { get; set; }
        public Application Application { get; set; }
        public virtual MigratoryInformation MigratoryInformation { get; set; }

    }
}
