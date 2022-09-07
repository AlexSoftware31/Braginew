using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.GenericInformations;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.PersonalInformation
{
    public interface IGenericInformationService : IRepository<GenericInformation, GenericInformationViewModel>, IBaseInterface<GenericInformation, GenericInformationViewModel>
    {
        Task<RequestResult<GenericInformationViewModel>> GetByApplicationId(int applicationId);
        Task<RequestResult<GenericInformationViewModel>> GetByAccessToken(string token);
        Task<RequestResult<GenericInformationViewModel>> CreateOrUpdate(GenericInformationViewModel genericInformation);
    }
}