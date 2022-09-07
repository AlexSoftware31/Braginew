using Bragi.DataLayer.Models.ApplicationStatus;
using Bragi.DataLayer.Models.Customs;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.Models.Steps;
using System.Collections.Generic;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Applications
{
    public class Application : BaseModel
    {
        public string Code { get; set; }
        public int Companions { get; set; }
        public int? QuestionId { get; set; }
        public int StatusId { get; set; }
        public int StepId { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public bool WasAssisted { get; set; }
        public string AssistantName { get; set; }
        public string AssistantRelation { get; set; }
        public ApplicationToken ApplicationToken { get; set; }
        public virtual Status Status { get; set; }
        public virtual IEnumerable<MigratoryInformation> MigratoryInformations { get; set; }
        public virtual GenericInformation GenericInformation { get; set; }
        public virtual IEnumerable<PublicHealth> PublicHealths { get; set; }
        public virtual IEnumerable<CustomsInformation> CustomsInformations { get; set; }
        public Step Step { get; set; }
    }
}