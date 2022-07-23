using CRR.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;

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
			if (!string.IsNullOrEmpty(Keyword))
			{
                Reviews = await _client.GetFromJsonAsync<List<TenantReview>>($"reviews/search/{Keyword}");
            }
			else
			{
                Reviews = new List<TenantReview>();
			}
			
			Insight = await _client.GetFromJsonAsync<Insight>("insights");
        }

        public IList<TenantReview>? Reviews { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }
		public Insight Insight { get; set; }

		public async Task<IActionResult> OnPostDownloadAsync(int id)
		{
            var res = await _client.GetAsync($"attachments/{id}");
			if (res.IsSuccessStatusCode)
			{
				Attachment? attachment = await res.Content.ReadFromJsonAsync<Attachment>();
				
                return File(attachment.Content, "application/force-download", attachment?.Name);
            }
			else
			{
                TempData["Notification"] = "Failed to download attachment";
			}
			
            return Page();
        }

    }
	
       public class Insight
	{
		public int Properties { get; set; }
		public int Reviews { get; set; }
		public int Users { get; set; }
	}

}
