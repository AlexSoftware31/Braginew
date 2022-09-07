using AutoMapper;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.ViewModels.GenericInformations;

namespace Bragi.BussinessLayer.Services.GenericInformations
{
    public class MaritalStatusService : LangBaseService<MaritalStatus, ProyectDbContext, MaritalStatusViewModel>, IMaritalStatusService
    {
        public MaritalStatusService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
