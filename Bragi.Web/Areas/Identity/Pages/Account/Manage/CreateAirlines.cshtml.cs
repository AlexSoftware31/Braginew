using Bragi.DataLayer.Models.Users;
using Bragi.DataLayer.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Bragi.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Administrator")]
    public class CreateAirlinesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateAirlinesModel(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        { 
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [BindProperty]
        public UserCreationViewModel UserCreationViewModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public void OnGet()
        {
            UserCreationViewModel = new UserCreationViewModel
            {
                Roles = _roleManager.Roles.ToList(),
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var oncreate = new User {UserName = UserCreationViewModel.User.UserName};
            var createdUsr = await _userManager.CreateAsync(oncreate,
                UserCreationViewModel.User.PassWord);
            if (createdUsr.Succeeded)
            {
                var assignRole = await _userManager.AddToRoleAsync(oncreate, UserCreationViewModel.Role);
                if(assignRole.Succeeded) StatusMessage = "User Created Successfully";
                return Page();
            }
            return Page();
        }
    }
}
