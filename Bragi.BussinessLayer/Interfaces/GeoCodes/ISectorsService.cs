using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using NetCoreUtilities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Interfaces.GeoCodes
{
    public interface ISectorsService : IRepository<Sectors, SectorsViewModel>, IBaseInterface<Sectors, SectorsViewModel>
    {
        Task<IEnumerable<SectorsViewModel>> GetAllSectors(string provinceCode, string municipCode);
        Task<GeoCodesViewModel> GetCodes(string geocode);
        Task<SectorsViewModel> GetSectorByGeoCode(string geoCode);
    }
}
