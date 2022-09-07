using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.ViewModels.Currencies;

namespace Bragi.DataLayer.Mappings.Currencies
{
    public class CurrencyMap:Profile
    {
        public CurrencyMap()
        {
            CreateMap<Currency, CurrencyViewModel>();
        }
    }
}
