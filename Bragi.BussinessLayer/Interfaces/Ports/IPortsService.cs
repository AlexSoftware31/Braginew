using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Ports;
using Bragi.DataLayer.ViewModels.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.Ports
{
    public interface IPortsService : IRepository<Port, PortViewModel>, IBaseInterface<Port, PortViewModel>
    {
        Task<RequestResult<IEnumerable<PortViewModel>>> GetAll(int transMethodId);
        Task<RequestResult<IEnumerable<PortViewModel>>> GetAllDominicanPorts(int transMethodId, string name);
    }
}