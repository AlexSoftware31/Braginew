using Bragi.DataLayer.Models.Agencies;
using Bragi.DataLayer.Models.Languages;
using System.Collections.Generic;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.DataLayer.Models.Questions
{
    public class Question : BaseModel, ILanguage
    {
 
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public bool IsBooleanResponse { get; set; }
        public virtual IEnumerable<QuestionResponse> QuestionResponse { get; set; }
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public string Spanish { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public string Portuguese { get; set; }
        public string Italian { get; set; }
        public string German { get; set; }
        public string French { get; set; }
    }
}
