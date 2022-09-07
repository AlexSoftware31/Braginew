using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Core;
using Bragi.DataLayer.Models.Countries;

namespace Bragi.DataLayer.Models.PublicHealths
{
    public class PublicHealthStopOver : BaseModel
    {
        public int CountryId { get; set; }
        public int PublicHealthId { get; set; }
        public Country Country { get; set; }
        public PublicHealth PublicHealth { get; set; }
    }
}
