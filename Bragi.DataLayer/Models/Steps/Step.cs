using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.DataLayer.Models.Steps
{
    public class Step : BaseModel
    {
        public string Name { get; set; }
        public StepsEnum StepsEnum { get; set; }
    }
}