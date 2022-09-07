using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.ViewModels.Applications;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.Applications
{
    public interface IApplicationTokenService : IRepository<ApplicationToken,ApplicationTokenViewModel>, IBaseInterface<ApplicationToken, ApplicationTokenViewModel>
    {
        Task<RequestResult<ApplicationTokenViewModel>> GetByToken(string token);
    }
}