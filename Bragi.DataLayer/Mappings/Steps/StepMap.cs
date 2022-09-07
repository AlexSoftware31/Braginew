using AutoMapper;
using Bragi.DataLayer.Models.Steps;
using Bragi.DataLayer.ViewModels.Steps;

namespace Bragi.DataLayer.Mappings.Steps
{
    public class StepMap : Profile
    {
        public StepMap()
        {
            CreateMap<Step, StepViewModel>();
        }
    }
}
