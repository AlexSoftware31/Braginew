using System.Collections.Generic;

namespace Bragi.DataLayer.ViewModels.MigratoryInfo
{
    public class MigratoryInfoStepViewModel
    {
        public List<MigratoryInformationViewModel> MigratoryInformations { get; set; }
        public int CurrentIndex { get; set; }
        public int PreviousIndex => CurrentIndex - 1;
    }
}