using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Auth;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.DgaVm;
using Bragi.DataLayer.ViewModels.UpdateStep;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;
using System.Threading.Tasks;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.BussinessLayer.Interfaces.Applications
{
    public interface IApplicationsService : IRepository<Application, ApplicationViewModel>, IBaseInterface<Application, ApplicationViewModel>
    {
        Task<RequestResult<ApplicationViewModel>> CreateApplication(AuthViewModel auth);
        Task<RequestResult<ApplicationViewModel>> DidExistReturnInfo(string token);
        Task<bool> DidExist(string token);
        Task<RequestResult<ApplicationViewModel>> UpdateStep(UpdateStepViewModel update);
        Task<RequestResult<ApplicationViewModel>> UpdateTermsAndConditions(int applicationId);
        Task<RequestResult<DgaOutputViewModel>> GetDgaOutputModel(OutputParams outputParams);
        Task<RequestResult> SetAssistant(AssistantViewModel assistant);
        Task<RequestResult> UpdateStatus(int applicationId, StatusEnum status);
        Task<RequestResult<bool>> IsEticketEmited(string accessToken, int?applicationId);
    }
}