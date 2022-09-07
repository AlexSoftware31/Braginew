using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Airlines
{
    public class AirlineViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public string OriginCode { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}
