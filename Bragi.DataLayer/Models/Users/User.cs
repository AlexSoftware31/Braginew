using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bragi.DataLayer.Models.Users
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public int? UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public string Location { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; } 
        public DateTime ModificationDate { get; set; }
        public string ModificatedBy { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
