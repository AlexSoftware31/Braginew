using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Ports
{
    public class PortViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public int? TransportationMethodId { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public bool IsDominicanPort { get; set; }
        public string FullName { get; set; }
    }
}
