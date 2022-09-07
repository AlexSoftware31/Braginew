using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.PublicHealths;

namespace Bragi.DataLayer.Models.Questions
{
    public class QuestionResponse : BaseModel
    {
        public int? ApplicationId { get; set; }
        public int ? PublicHealthId { get; set; }
        public int QuestionId { get; set; }
        public string TextReponse { get; set; }
        public bool BoolResponse { get; set; }
        public virtual Application Application { get; set; }
        public virtual Question Question { get; set; }
        public virtual PublicHealth PublicHealth { get; set; }

    }
}