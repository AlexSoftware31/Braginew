using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Steps;
using Bragi.BussinessLayer.Services.Core;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Steps;
using Bragi.DataLayer.ViewModels.Steps;

namespace Bragi.BussinessLayer.Services.Steps
{
    public class StepsService : BaseService<Step, ProyectDbContext, StepViewModel>, IStepsService
    {
        public StepsService(ProyectDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
