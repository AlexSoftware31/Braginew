using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Enums;

namespace Bragi.DataLayer.Models.ApplicationStatus
{
    public class Status : BaseModel
    {
        public string Name { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}
