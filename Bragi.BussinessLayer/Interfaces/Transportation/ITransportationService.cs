using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Transportation;
using Bragi.DataLayer.ViewModels.Transportation;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Transportation
{
    public interface ITransportationService : IRepository<TransportationMethod, TransportationMethodViewModel>,
        IBaseInterface<TransportationMethod,TransportationMethodViewModel>,ILangBaseService<TransportationMethod, TransportationMethodViewModel>
    {
    }
}