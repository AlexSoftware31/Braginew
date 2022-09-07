using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.Airlines
{
    public class Airline : BaseModel
    {
        public string Code { get; set; }
        public string OriginCode { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
