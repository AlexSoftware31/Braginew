using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.ViewModels.Captcha
{
   public class CaptchaResponseViewModel
    {
        public bool Success { get; set; }
        public string ChallengeTs { get; set; }
        public string HostName { get; set; }
        public string[] ErrorCodes { get; set; }
    }
}
