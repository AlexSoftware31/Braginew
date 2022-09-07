using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.RequestLogs;
using Bragi.DataLayer.ViewModels.RequestLogs;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.RequestLogs
{
    public interface IRequestLogService : IRepository<RequestLog, RequestLogViewModel>, IBaseInterface<RequestLog, RequestLogViewModel>
    {
    }
}