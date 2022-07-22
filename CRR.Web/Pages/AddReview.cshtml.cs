using CRR.Models;
using CRR.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using System.IO.Compression;
using System.Security.Claims;

namespace CRR.Web.Pages
{
	[Authorize(Roles = "landlord")]
    public class AddReviewModel : PageModel
    {
        private readonly HttpClient _client;
        public AddReviewModel(HttpClient agent)
        {
            _client = agent;

            Ratings = new Rating[]
            {
                new Rating
                {
                    Description = "Cleanliness",
                    Value = 1
                },
                new Rating
                {
                    Description = "Payments",
                    Value = 1
                },
                new Rating
                {
                    Description = "Behavior",
                    Value = 1
                },
                new Rating
                {
                    Description = "Recommendation",
                    Value = 1
                },
            };
			
        }
		
        public async Task OnGet()
        {
            Properties = await GetPropertiesAsync();

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

            return await _client.GetFromJsonAsync<Property[]>($"Properties/{currentUserId}");
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
			if (!ModelState.IsValid)
			{
                return Page();
			}

            ClaimsPrincipal currentUser = this.User;
            string? currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var review = new TenantReview
            {
                ApplicationUserId = currentUserId,
				TenantCNIC = ReviewModel.TenantCNIC,
				TenantName = ReviewModel.TenantName,
				Date = DateTime.Now,
				StayDuration = ReviewModel.StayDuration,
				Details = ReviewModel.Details,
				PropertyId = ReviewModel.PropertyId,
                RatingOverview = Ratings.Count() > 0 ? Math.Round(Ratings.Average(r => r.Value), 0, MidpointRounding.ToPositiveInfinity) : 1
        };
			
			foreach (var item in ReviewModel.Attachments)
			{
				using (var memoryStream = new MemoryStream())
				{
					// Upload the file if less than 5 MB
					if (memoryStream.Length < 5242880)
					{
						var file = new Attachment()
						{
                            Name = item.FileName,
							Content = memoryStream.ToArray()
						};

                        review.Attachments.Add(file);
					}
				}
			}

            review.Ratings.AddRange(Ratings);

            var res = await _client.PostAsJsonAsync("reviews/add", review);
			if (res.IsSuccessStatusCode)
			{
                TempData["Notification"] = "Review was successfully published";
                //review = await res.Content.ReadFromJsonAsync<TenantReview>();
			}
			else
			{
                ModelState.AddModelError("File", await res.Content.ReadAsStringAsync());
			}


			return Page();
        }
    }
}
