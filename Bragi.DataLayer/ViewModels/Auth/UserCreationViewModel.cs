using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Users;
using Bragi.DataLayer.ViewModels.Users;
using Microsoft.AspNetCore.Identity;

namespace Bragi.DataLayer.ViewModels.Auth
{
    public class UserCreationViewModel
    {
        public List<UserType> UserTypes { get; set; } = new List<UserType>();
        public List<IdentityRole> Roles { get; set; }
        public UserViewModel User { get; set; } = new UserViewModel();
        public string Role { get; set; }
    }
}
