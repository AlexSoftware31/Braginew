using System.Text.Json.Serialization;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Applications
{
    public class ApplicationToken : BaseModel
    {
        public string Token { get; set; }
        public bool IsDisable { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}