using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.ViewModels.Applications
{
    public class AssistantViewModel
    {
        public int ApplicationId { get; set; }
        public bool WasAssisted { get; set; }
        public string AssistantName { get; set; }
        public string AssistantRelation { get; set; }

    }
}
