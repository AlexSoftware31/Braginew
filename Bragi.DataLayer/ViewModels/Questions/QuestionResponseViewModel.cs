using Bragi.DataLayer.ViewModels.Applications;
using Bragi.DataLayer.ViewModels.Core;
using Bragi.DataLayer.ViewModels.PublicHealths;

namespace Bragi.DataLayer.ViewModels.Questions
{
    public class QuestionResponseViewModel : BaseViewModel
    {
        public int? ApplicationId { get; set; }
        public int? PublicHealthId { get; set; }
        public int QuestionId { get; set; }
        public string TextReponse { get; set; }
        public bool BoolResponse { get; set; }
        public virtual ApplicationViewModel Application { get; set; }
        public virtual QuestionViewModel Question { get; set; }
        public virtual PublicHealthViewModel PublicHealth { get; set; }
    }
}