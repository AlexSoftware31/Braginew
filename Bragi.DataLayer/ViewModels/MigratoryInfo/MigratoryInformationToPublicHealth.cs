using Bragi.DataLayer.ViewModels.GenericInformations;
using System.Collections.Generic;

namespace Bragi.DataLayer.ViewModels.MigratoryInfo
{
    public class MigratoryInformationToPublicHealth
    {
        public GenericInformationViewModel GenericInformation { get; set; }
        public List<MigratoryInformationViewModel> MigratoryInformation { get; set; }
        public int Companions { get; set; }
        public int PersonIndex { get; set; }
        public int PreviousIndex { get; set; }
        public int TotalCreated { get; set; }
        public string Token { get; set; }
    }
}
