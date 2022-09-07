using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.ApplicationStatus
{
    public class StatusViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}
