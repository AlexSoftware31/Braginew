using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Customs
{
    public interface IDeclaredMerchService : IRepository<DeclaredMerch, DeclaredMerchViewModel>, IBaseInterface<DeclaredMerch, DeclaredMerchViewModel>
    {
    }
}
