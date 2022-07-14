using CRR.Models;
using CRR.Web.Controllers;
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
        private readonly HttpAgent _http;
		public BecomeContributorModel(HttpAgent http)
		{
			_http = http;
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

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var response = await _http.HttpClient.PostAsJsonAsync("users/addto/landlord", new Landlord { Id = currentUserID, About = Landlord.About, PermanentAddress = Landlord.PermanentAdress });

			if(response.IsSuccessStatusCode)
			    return RedirectToPage("./AddProperties");

            return Page();
        }
    }
}
