using System.Collections.Generic;

namespace Bragi.DataLayer.ViewModels.DgaVm
{
    public class DgaOutputViewModel
    {
        public int ApplicationId { get; set; }
        public int Companions { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public bool WasAssisted { get; set; }
        public string AssistantName { get; set; }
        public string AssistantRelation { get; set; }
        public string QrCode { get; set; }
        public GenericInformationViewModelDga GenericInformation { get; set; }
        public IEnumerable<MigratoryInformationDga> MigratoryInformations { get; set; }
    }
}
