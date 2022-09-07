﻿using Bragi.DataLayer.ViewModels.Core;

namespace Bragi.DataLayer.ViewModels.Transportation
{
    public class TransportationMethodViewModel : BaseViewModel, ILanguageViewModel
    {
        public string Text { get; set; }
        public string Spanish { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public string Portuguese { get; set; }
        public string Italian { get; set; }
        public string German { get; set; }
        public string French { get; set; }
    }
}
