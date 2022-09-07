using System;
using System.Collections.Generic;
using System.Text;

namespace Bragi.DataLayer.ViewModels.Jwt
{
   public class JwtViewModel
    {
        public string BearerToken { get; set; }
        public DateTime Expiration { get; set; }

    }
}
