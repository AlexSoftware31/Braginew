using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.PublicHealths
{
    public interface IPublicHealthService : IRepository<PublicHealth,PublicHealthViewModel>, IBaseInterface<PublicHealth, PublicHealthViewModel>
    {
        Task<RequestResult<IEnumerable<PublicHealthViewModel>>> GetByApplicationId(int applicationId);
        Task<RequestResult> CreatePublicHealth(int applicationId, LanguageEnum lang);
        Task<RequestResult<PublicHealthViewModel>> EditAsync(PublicHealthViewModel viewModel);
        Task<RequestResult<bool>> IsReadyToEticketEmission(int applicationId, int personIndex);
        Task<RequestResult<bool>> IsReadyToEticketEmission(int applicationId);
    }
}