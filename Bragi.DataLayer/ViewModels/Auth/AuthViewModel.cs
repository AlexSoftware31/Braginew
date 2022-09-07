using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.ViewModels.Questions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bragi.DataLayer.ViewModels.Auth
{
    public class AuthViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
        public int QuestionId { get; set; }
        public string Response { get; set; }
        public int AcompanyNumber { get; set; }
        public string ApplicationCode { get; set; }
        public bool HasErrors { get; set; }
        public bool HasCompanion { get; set; }
    }
}