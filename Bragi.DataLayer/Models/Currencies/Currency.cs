using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Currencies
{
    public class Currency : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
