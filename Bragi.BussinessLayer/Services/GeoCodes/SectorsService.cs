using System;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bragi.BussinessLayer.Services.Core;

namespace Bragi.BussinessLayer.Services.GeoCodes
{
    public class SectorsService : BaseService<Sectors, ProyectDbContext, SectorsViewModel>, ISectorsService
    {
        private readonly IMapper _mapper;
        private readonly IMunicipalityService _municipalityService;
        private readonly IProvinceService _provinceService;
        public SectorsService(ProyectDbContext context, IMapper mapper, IMunicipalityService municipalityService, IProvinceService provinceService) : base(context, mapper)
        {
            _mapper = mapper;
            _municipalityService = municipalityService;
            _provinceService = provinceService;
        }

        public async Task<IEnumerable<SectorsViewModel>> GetAllSectors(string provinceCode, string municipCode)
        {
            var result = await GetQueryable(x => x.Municipalities == municipCode && x.Province == provinceCode)
                .OrderBy(x => x.ToponomyName).ToListAsync();
            return _mapper.Map<IEnumerable<SectorsViewModel>>(result);
        }

        public async Task<GeoCodesViewModel> GetCodes(string geocode)
        {
            var selectedValues = await FindBy(x => x.GeoCode == geocode)
                .FirstOrDefaultAsync();
            var provinces = await _provinceService.GetAll();
            var municip = await _municipalityService.GetAllMunicipalitiesByProvinceCode(selectedValues.Province);
            var sectors = await GetAllSectors(selectedValues.Province, selectedValues.Municipalities);
            var geo = new GeoCodesViewModel
            {
                MunicipalityCode = selectedValues.Municipalities,
                ProvinceCode = selectedValues.Province,
                SectorCode = selectedValues.GeoCode,
                Municipalities = municip,
                Provinces = provinces,
                Sectors = sectors
            };
            return geo;
        }

        public async Task<SectorsViewModel> GetSectorByGeoCode(string geoCode)
        {
            return await GetBy(x => x.GeoCode == geoCode);
        }

       
    }
}
