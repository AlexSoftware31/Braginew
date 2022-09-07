using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Currencies
{
    public class CurrencyViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
