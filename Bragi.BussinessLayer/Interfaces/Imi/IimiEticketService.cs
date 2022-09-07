using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.ImiEtickets;
using Bragi.DataLayer.ViewModels.ImiEtickets;
using System.Threading.Tasks;
using NetCoreUtilities.Interfaces;
using NetCoreUtilities.Models;

namespace Bragi.BussinessLayer.Interfaces.Imi
{
    public interface IimiEticketService : IRepository<T01_Etickets, T01_EticketsViewModel>, IBaseInterface<T01_Etickets, T01_EticketsViewModel>
    {
        
    }
}