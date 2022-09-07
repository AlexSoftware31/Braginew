using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.ViewModels.Customs;

namespace Bragi.BussinessLayer.Services.Customs
{
    public class DeclaredMerchService : BaseService<DeclaredMerch, ProyectDbContext, DeclaredMerchViewModel>, IDeclaredMerchService
    {
        public DeclaredMerchService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
