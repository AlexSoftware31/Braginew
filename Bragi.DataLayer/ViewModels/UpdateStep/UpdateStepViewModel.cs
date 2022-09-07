using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.DataLayer.ViewModels.UpdateStep
{
    public class UpdateStepViewModel
    {
        public int ApplicationId { get; set; }
        public StepsEnum StepsEnum { get; set; }
    }
}
