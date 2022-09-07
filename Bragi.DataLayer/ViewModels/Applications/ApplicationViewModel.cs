using Bragi.DataLayer.ViewModels.ApplicationStatus;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Bragi.DataLayer.ViewModels.Questions;
using Bragi.DataLayer.ViewModels.Steps;
using System.Collections.Generic;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Applications
{
    public class ApplicationViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public int QuestionId { get; set; }
        public int Companions { get; set; }
        public int StatusId { get; set; }
        public int StepId { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public bool WasAssisted { get; set; }
        public string AssistantName { get; set; }
        public string AssistantRelation { get; set; }
        public ApplicationTokenViewModel ApplicationToken { get; set; }
        public virtual StatusViewModel Status { get; set; }
        public virtual QuestionViewModel Question { get; set; }
        public virtual IEnumerable<MigratoryInformationViewModel> MigratoryInformations { get; set; }
        public virtual GenericInformationViewModel GenericInformation { get; set; }
        public StepViewModel Step { get; set; }
    }
}