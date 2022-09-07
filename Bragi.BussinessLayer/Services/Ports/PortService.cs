using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Ports;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Ports;
using Bragi.DataLayer.ViewModels.Ports;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Services.Ports
{
    public class PortService : BaseService<Port, ProyectDbContext, PortViewModel>, IPortsService
    {
        private readonly IMapper _mapper;
        public PortService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }


        public async Task<RequestResult<IEnumerable<PortViewModel>>> GetAll(int transMethodId)
        {
            var reqResult = RequestResult<IEnumerable<PortViewModel>>.Failed();
            var result = await GetQueryable(x => x.TransportationMethodId == transMethodId).ToListAsync();
            //var result = await GetPagedAsync(1, 100, null, x => x.IsDominicanPort);
            if (result != null)
            {
                return RequestResult<IEnumerable<PortViewModel>>.Success(_mapper.Map<IEnumerable<PortViewModel>>(result.OrderBy(x => x.Name)));
            }
            return reqResult.AddError("Empty Result");
        }

        public async Task<RequestResult<IEnumerable<PortViewModel>>> GetAllDominicanPorts(int transMethodId, string name)
        {
            var reqResult = RequestResult<IEnumerable<PortViewModel>>.Failed();
            var query = GetQueryable(x => x.TransportationMethodId == transMethodId && x.IsDominicanPort);
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{name}%"));
            }
            var result = await query.ToListAsync();
            if (result != null)
            {
                return RequestResult<IEnumerable<PortViewModel>>.Success(_mapper.Map<IEnumerable<PortViewModel>>(result.OrderBy(x => x.Name)));
            }
            return reqResult.AddError("Empty Result");
        }
    }
}
