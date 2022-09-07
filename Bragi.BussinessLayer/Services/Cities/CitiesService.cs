using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bragi.BussinessLayer.Interfaces.Cities;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Cities;
using Bragi.DataLayer.ViewModels.Cities;
using Microsoft.EntityFrameworkCore;
using NetCoreUtilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bragi.BussinessLayer.Services.Cities
{
    public class CitiesService : BaseService<City, ProyectDbContext, CityViewModel>, ICitiesService
    {
        private readonly IMapper _mapper;
        private readonly ProyectDbContext _context;
        public CitiesService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CityViewModel>> GetByIso2(string iso2Code)
        {
            var mapped = await GetQueryable(x => x.Iso2CountryCode == iso2Code).AsNoTracking()
                .ProjectTo<CityViewModel>(_mapper.ConfigurationProvider)
                           .ToListAsync();
            return mapped;
        }

        public async Task<DataCollection<CityViewModel>> GetPagedByCityName(string iso2Country, string name, int pageNumber = 1, int qty = 50)
        {
            var pg = await GetPagedAsync(pageNumber, qty, predicate: x => x.Iso2CountryCode == iso2Country && x.Name.Contains(name), orderby: cities => cities.OrderBy(x => x.Name));
            return pg;
        }


        public async Task<IEnumerable<CityViewModel>> GetByCityName(string iso2Country, string name)
        {
            var queryable = GetQueryable();

            if (name.Length <= 3)
            {
                queryable = queryable.Where(x => x.Iso2CountryCode == iso2Country && x.Name == name);
            }
            else
            {
                queryable = queryable.Where(x => x.Iso2CountryCode == iso2Country && x.Name.Contains(name));
            }

            return await queryable.ProjectTo<CityViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}