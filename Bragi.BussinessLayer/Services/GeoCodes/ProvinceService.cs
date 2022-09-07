using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.ViewModels.GeoCodes;

namespace Bragi.BussinessLayer.Services.GeoCodes
{
    public class ProvinceService : BaseService<Provinces,ProyectDbContext,ProvincesViewModel>, IProvinceService
    {
        public ProvinceService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
