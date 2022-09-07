using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.ViewModels.Agencys;
using Bragi.DataLayer.ViewModels.Core;
using System.Collections.Generic;

namespace Bragi.DataLayer.ViewModels.Questions
{
    public class QuestionViewModel : BaseViewModel, ILanguageViewModel, ILanguage
    {
        public string Text { get; set; }
        public string Spanish { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public string Portuguese { get; set; }
        public string French { get; set; }
        public string Italian { get; set; }
        public string German { get; set; }
        public int AgencyId { get; set; }
        public virtual AgencyViewModel Agency { get; set; }
        public bool IsBooleanResponse { get; set; }
        public virtual IEnumerable<QuestionResponseViewModel> QuestionResponse { get; set; }
    }
}
