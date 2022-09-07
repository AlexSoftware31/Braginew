using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.ViewModels.ETickets
{
    public class EmissionViewModel
    {
        public EticketViewModel Eticket { get; set; }
        public Byte[] QrCode { get; set; }
        public bool IsPrint { get; set; }
        public string Token { get; set; }
    }
}
