using Bragi.BussinessLayer.Interfaces.Core;
using Bragi.DataLayer.Models.Steps;
using Bragi.DataLayer.ViewModels.Steps;
using NetCoreUtilities.Interfaces;

namespace Bragi.BussinessLayer.Interfaces.Steps
{
    public interface IStepsService : IRepository<Step, StepViewModel>, IBaseInterface<Step, StepViewModel>
    {

    }
}