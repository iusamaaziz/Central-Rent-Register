using CRR.Models;
using CRR.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Security.Claims;

namespace CRR.Web.Pages
{
	[Authorize(Roles = "landlord")]
	public class AddPropertiesModel : PageModel
    {
        private readonly HttpClient _client;
        public AddPropertiesModel(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> OnGet()
        {
			ClaimsPrincipal currentUser = this.User;
			currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			Properties = await _client.GetFromJsonAsync<Property[]>($"Properties/{currentUserId}");
			
			PropertyModel = new();
			
			return Page();
        }

		[BindProperty]
		public PropertyModel PropertyModel { get; set; }
		[BindProperty]
		public Property[] Properties { get; set; }

		private string? currentUserId { get; set; }


		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			ClaimsPrincipal currentUser = this.User;
			var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var prop = new Property()
			{
				ApplicationUserId = currentUserID,
				Address = PropertyModel.Address,
				City = PropertyModel.City,
				State = PropertyModel.State,
				Country = PropertyModel.Country,
				Type = PropertyModel.Type
			};

			var response = await _client.PostAsJsonAsync("Properties/upsert", prop);
			if (response.IsSuccessStatusCode)
				return RedirectToPage("./AddProperties");

			else throw new Exception();
		}
	}
}
