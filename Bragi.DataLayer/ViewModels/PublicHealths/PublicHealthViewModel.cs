using System;
using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Bragi.DataLayer.ViewModels.Questions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.PublicHealths
{
    public class PublicHealthViewModel : BaseViewModel
    {
        public int ApplicationId { get; set; }
        public int MigratoryInformationId { get; set; }
        public string PhoneNumber { get; set; }
        public string SpecificSymptoms { get; set; }
        public DateTime? SymptomsDate { get; set; }
        public virtual List<QuestionResponseViewModel> QuestionResponse { get; set; }
        public virtual ApplicationViewModel Application { get; set; }
        public virtual MigratoryInformationViewModel MigratoryInformation { get; set; }
        public virtual List<PublicHealthCountriesViewModel> PublicHealthCountries { get; set; }
        public virtual List<PublicHealthStopOverViewModel> PublicHealthStopOvers { get; set; }
        [NotMapped]
        public int PersonIndex { get; set; }
        [NotMapped]
        public bool IsUnderAge { get; set; }
        [NotMapped]
        public bool IsValid { get; set; }
        [NotMapped]
        public bool IsArrival { get; set; }
        [NotMapped]
        public bool IsLast { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
