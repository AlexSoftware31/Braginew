using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Imi;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.ImiEtickets;
using Bragi.DataLayer.ViewModels.ImiEtickets;
using NetCoreUtilities.Models;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.Imi
{
    public class ImiEticketService : BaseService<T01_Etickets, ImiDbContext, T01_EticketsViewModel>, IimiEticketService
    {
        private readonly ImiDbContext _context;
        public ImiEticketService(ImiDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

      
    }
}
