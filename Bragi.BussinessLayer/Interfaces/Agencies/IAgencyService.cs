using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Agencies;
using Bragi.DataLayer.ViewModels.Agencys;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Agencies
{
    public interface IAgencyService : IRepository<Agency, AgencyViewModel>,IBaseInterface<Agency, AgencyViewModel>
    {

    }
}