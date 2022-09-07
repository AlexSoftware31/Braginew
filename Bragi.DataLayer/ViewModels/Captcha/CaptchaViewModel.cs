using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.ViewModels.Captcha
{
    public class CaptchaViewModel
    {
        public string Response { get; set; }
        public string RemoteIp { get; set; } = "";
    }
}
