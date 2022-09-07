using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using NetCoreUtilities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.GeoCodes
{
    public interface IMunicipalityService : IRepository<Municipality, MunicipalityViewModel>, IBaseInterface<Municipality, MunicipalityViewModel>
    {
        Task<List<MunicipalityViewModel>> GetAllMunicipalitiesByProvinceCode(string provinceCode);
    }
}