using CRR.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRR.Web.Pages
{
	[Authorize]
    public class HomeModel : PageModel
    {
        private HttpClient _client;

		public HomeModel(HttpClient agent)
		{
            _client = agent;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Reviews = await _client.GetFromJsonAsync<List<TenantReview>>("reviews");

            return Page();
        }

		[BindProperty]
		public List<TenantReview> Reviews { get; set; }
	}
}
