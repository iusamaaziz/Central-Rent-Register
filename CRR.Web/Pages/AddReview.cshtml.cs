using CRR.Models;
using CRR.Web.Controllers;
using CRR.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Security.Claims;

namespace CRR.Web.Pages
{
	[Authorize(Roles = "landlord")]
    public class AddReviewModel : PageModel
    {
        private readonly HttpAgent _agent;
        public AddReviewModel(HttpAgent agent)
        {
            _agent = agent;
        }
        public async Task OnGet()
        {
            Properties = await GetPropertiesAsync();

            Ratings = new Rating[]
            {
                new Rating
                {
                    Description = "Cleanliness",
                    Value = 0
                },
                new Rating
                {
                    Description = "Payments",
                    Value = 0
                },
                new Rating
                {
                    Description = "Behavior",
                    Value = 0
                },
                new Rating
                {
                    Description = "Recommendation",
                    Value = 0
                },
            };

            ReviewModel = new();
        }

        [BindProperty]
        public Property[] Properties { get; set; }
		[BindProperty]
		public Rating[] Ratings { get; set; }
		[BindProperty]
		public TenantReviewModel ReviewModel { get; set; }

		public async Task<PageResult> OnPostAsync()
		{
            if (!ModelState.IsValid)
                return Page();

            return Page();
		}

		private async Task<Property[]> GetPropertiesAsync()
		{
            ClaimsPrincipal currentUser = this.User;
            string? currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await _agent.HttpClient.GetFromJsonAsync<Property[]>($"Properties/{currentUserId}");
        }
    }
}
