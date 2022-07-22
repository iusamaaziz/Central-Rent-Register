using CRR.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task OnGetAsync()
        {
            //Reviews = await _client.GetFromJsonAsync<List<TenantReview>>("reviews");

			if (!string.IsNullOrEmpty(SearchString))
			{
                Reviews = await _client.GetFromJsonAsync<List<TenantReview>>($"reviews/search/{SearchString}");
            }
			else
			{
                Reviews = new List<TenantReview>();
			}
			
            //return Page();
        }

        public IList<TenantReview>? Reviews { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        //[BindProperty]
		//public List<TenantReview> Reviews { get; set; }
	}
}
