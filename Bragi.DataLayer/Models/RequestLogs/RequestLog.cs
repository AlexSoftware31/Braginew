using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Core;

namespace Bragi.DataLayer.Models.RequestLogs
{
    public class RequestLog : BaseModel
    {
        public string Method { get; set; }
        public string  Uri { get; set; }
        public string StatusCode { get; set; }
        public string RequestHeader { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public double RequestMils  { get; set; }
        
        public RequestLog()
        {
            CreatedBy = Environment.MachineName;
        }
    }
}
