using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Airlines;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.ViewModels.Airlines;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bragi.BussinessLayer.Services.Airlines
{
    public class AirlineService : BaseService<Airline, ProyectDbContext, AirlineViewModel>, IAirlineService
    {
        public AirlineService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
