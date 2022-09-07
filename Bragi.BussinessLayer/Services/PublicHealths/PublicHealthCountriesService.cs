using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.ViewModels.PublicHealths;

namespace Bragi.BussinessLayer.Services.PublicHealths
{
   public class PublicHealthCountriesService: BaseService<PublicHealthCountries,ProyectDbContext,PublicHealthCountriesViewModel>,IPublicHealthCountriesService
    {
        public PublicHealthCountriesService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
