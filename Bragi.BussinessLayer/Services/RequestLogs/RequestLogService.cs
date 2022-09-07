using AutoMapper;
using Bragi.BussinessLayer.Interfaces.RequestLogs;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.RequestLogs;
using Bragi.DataLayer.ViewModels.RequestLogs;

namespace Bragi.BussinessLayer.Services.RequestLogs
{
    public class RequestLogService : BaseService<RequestLog, ProyectDbContext, RequestLogViewModel>, IRequestLogService
    {
        public RequestLogService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
