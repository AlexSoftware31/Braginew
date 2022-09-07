using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.ETickets;
using Bragi.DataLayer.ViewModels.ETickets;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.ETickets
{
    public interface IEticketsService : IRepository<Eticket,EticketViewModel>,IBaseInterface<Eticket, EticketViewModel>
    {
        Task<RequestResult<EticketViewModel>> PrepareAndCreate(int applicationId);
        Task<RequestResult<EticketViewModel>> GetByApplicationId(int applicationId);
        Task<RequestResult<EticketViewModel>> GetByApplicationIdInclude(int applicationId);
        Task<RequestResult<EticketViewModel>> GetBySequenceQrCode(string sequenceQrCode);
        Task<RequestResult<MigratoryInfoAirlineViewModel>> GetMigratoryInfoToAirlinesCheckin(string qrCode);
        Task<RequestResult> SavePassengersIntoImi(int applicationId);

    }
}