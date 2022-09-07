using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.ViewModels.Customs;
using Bragi.DataLayer.ViewModels.DgaVm;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.Customs
{
    public interface ICustomsService : IRepository<CustomsInformation, CustomsInformationWiewModel>, IBaseInterface<CustomsInformation, CustomsInformationWiewModel>
    {
        Task<RequestResult<IEnumerable<CustomsInformationWiewModel>>> GetByApplicationId(int applicationId);
        Task<RequestResult<CustomsInformationWiewModel>> UpdateWithConditions(CustomsInformationWiewModel entity);
        Task<RequestResult<DgaOutputViewModel>> SendInformationToCustomsWs(OutputParams outputParams);
        Task<RequestResult> CreateCustomsForEachPerson(int applicationId);
        RequestResult<bool> IsPublicHealthReady(int applicationId, int personIndex);
    }
}