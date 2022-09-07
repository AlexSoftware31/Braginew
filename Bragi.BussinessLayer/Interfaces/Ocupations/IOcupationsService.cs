using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Ocupations;
using Bragi.DataLayer.ViewModels.Ocupations;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Ocupations
{
    public interface IOcupationsService : IRepository<Ocupation, OcupationViewModel>, IBaseInterface<Ocupation, OcupationViewModel>,ILangBaseService<Ocupation, OcupationViewModel>
    {
    }
}