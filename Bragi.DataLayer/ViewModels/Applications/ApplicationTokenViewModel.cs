using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Applications
{
    public class ApplicationTokenViewModel : BaseViewModel
    {
        public string Token { get; set; }
        public bool IsDisable { get; set; }
        public int ApplicationId { get; set; }
        public ApplicationViewModel Application { get; set; }
    }
}
