using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Currencies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Customs
{
    public class CustomsInformationWiewModel : BaseViewModel
    {
        public int ApplicationId { get; set; }
        public int MigratoryInformationId { get; set; }

        public int? CurrencyId { get; set; }
        public bool ExceedsMoneyLimit { get; set; }
        public bool IsValuesOwner { get; set; }
        public bool HasAnimalsOrFood { get; set; }
        public bool HasMerchWithTaxValue { get; set; }
        public string SenderName { get; set; }
        public string SenderLastName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverLastName { get; set; }
        public string RelationShip { get; set; }
        public string WorthDestiny { get; set; }
        public bool IsUnderAge { get; set; }
        public string DeclaredOriginValue { get; set; }
        public decimal? Ammount { get; set; }
        public int? CurrencyMerchandiseId { get; set; }
        public decimal ValueOfMerchandise { get; set; } = 1;
        public virtual CurrencyViewModel CurrencyMerchandise { get; set; }
        public virtual CurrencyViewModel Currency { get; set; }
        public virtual IEnumerable<DeclaredMerchViewModel> DeclaredMerchs { get; set; } = new List<DeclaredMerchViewModel>();
        public virtual ApplicationViewModel Application { get; set; }
        [NotMapped]
        public int PersonIndex { get; set; }
        [NotMapped] 
        public string Token { get; set; }
        [NotMapped] 
        public bool IsArrival { get; set; }
        [NotMapped]
        public DeclaredMerchViewModel DeclaredMerch { get; set; }
        [NotMapped]
        public int Total { get; set; }
        
    }
}
