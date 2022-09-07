using System;
using System.Collections.Generic;
using System.Text;
using Bragi.DataLayer.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Bragi.DataLayer.ViewModels.Users
{
   public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
