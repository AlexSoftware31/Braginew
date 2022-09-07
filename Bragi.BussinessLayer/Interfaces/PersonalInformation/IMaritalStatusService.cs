using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.GenericInformations;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.PersonalInformation
{
    public interface IMaritalStatusService : IRepository<MaritalStatus, MaritalStatusViewModel>, IBaseInterface<MaritalStatus, MaritalStatusViewModel>, ILangBaseService<MaritalStatus, MaritalStatusViewModel>
    {
    }
}
