using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.MigratoryInfo
{
    public interface IMigratoryInfoService : IRepository<MigratoryInformation, MigratoryInformationViewModel>, IBaseInterface<MigratoryInformation, MigratoryInformationViewModel>
    {
        Task<RequestResult<List<MigratoryInformationViewModel>>> GetInformationByApplicationId(int applicationId);
        Task<RequestResult<MigratoryInformationViewModel>> DispatchCreation(MigratoryInformationViewModel entity);
        Task<RequestResult<MigratoryInformationViewModel>> DispatchUpdate(MigratoryInformationViewModel entity);
        Task<RequestResult<MigratoryInformationViewModel>> CreateWithDependant(MigratoryInformationViewModel entity);
        Task<RequestResult<MigratoryInformationViewModel>> CreateDependantWithDiferentAddress(MigratoryInformationViewModel entity);
        Task<RequestResult<MigratoryInformationViewModel>> UpdateWithDependant(MigratoryInformationViewModel entity);

        Task<RequestResult<MigratoryInformationViewModel>> UpdateDependantWithDiferentAddress(
            MigratoryInformationViewModel entity);
        Task<RequestResult<MigratoryInfoToCustoms>> GetByApplicationIdAndCustoms(int applicationId);
        Task<RequestResult<MigratoryInformationToPublicHealth>> GetByApplicationIdAndPublicHealth(int applicationId);
        Task<RequestResult<IEnumerable<MigratoryInformationViewModel>>> GetToPostDga(OutputParams outputParams);
        Task<List<MigratoryInformationViewModel>> GetAllMigratoryInformationsByAppId(int appId);
        Task<RequestResult<bool>> IsReadyToDga(int applicationId, int totalCompanions);

    }
}