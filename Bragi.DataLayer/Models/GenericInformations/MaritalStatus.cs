using System.ComponentModel.DataAnnotations;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.Languages;

namespace Bragi.DataLayer.Models.GenericInformations
{
    public class MaritalStatus : BaseModel, ILanguage
    {
        [StringLength(150)] 
        public string Spanish { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public string Portuguese { get; set; }
        public string Italian { get; set; }
        public string German { get; set; }
        public string French { get; set; }
    }
}