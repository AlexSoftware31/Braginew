using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Steps
{
    public class StepViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public StepsEnum StepsEnum { get; set; }
    }
}
