using CRR.Models;
using CRR.Web.Data;
using CRR.Web.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CRR.Web.Pages
{
    public class BecomeContributorModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
		
        private readonly HttpClient _client;
		public BecomeContributorModel(HttpClient http, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_client = http;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
		}

		[BindProperty]
		public LandlordModel Landlord { get; set; }

		public IActionResult OnGet()
        {
            Landlord = new LandlordModel();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            user.About = Landlord.About;
            user.PermanentAddress = Landlord.PermanentAdress;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            if (!await _roleManager.RoleExistsAsync("landlord"))
                await _roleManager.CreateAsync(new IdentityRole("landlord"));

            if(!await _userManager.IsInRoleAsync(user, "landlord"))
                await _userManager.AddToRoleAsync(user, "landlord");
			
            await _signInManager.RefreshSignInAsync(user);
            return RedirectToPage("./AddProperties");
        }
    }
}
