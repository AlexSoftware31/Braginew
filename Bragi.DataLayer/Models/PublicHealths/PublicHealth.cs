using System;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.Models.Questions;
using System.Collections.Generic;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.PublicHealths
{
    public class PublicHealth : BaseModel
    {
        public int ApplicationId { get; set; }
        public int MigratoryInformationId { get; set; }
        public string PhoneNumber { get; set; }
        public string SpecificSymptoms { get; set; }
        public DateTime? SymptomsDate { get; set; }
        public virtual List<QuestionResponse> QuestionResponse { get; set; }
        public virtual Application Application { get; set; }
        public virtual MigratoryInformation MigratoryInformation { get; set; }
        public virtual List<PublicHealthCountries> PublicHealthCountries { get; set; }
        public virtual List<PublicHealthStopOver> PublicHealthStopOvers { get; set; }
    }
}
