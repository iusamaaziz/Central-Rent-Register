using CRR.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRR.Web.Pages
{
	[Authorize]
    public class HomeModel : PageModel
    {
		public HomeModel()
		{
            Reviews = new List<TenantReview>
            {
                new TenantReview
				{
                     Date = DateTime.Now,
                     Details = "Nagxi iri farus kiam alproksimigxis mi ni pli sxnuregon subteni la pafilon gxemi gxi tiam kuragxis sur la ke estis",
                     TenantName = "La laborigis",
                     Property = new Property
					 {
                          Address = "Vidajxo aux amikojn",
                          City = "Okara",
                          State = "AU",
                          Country = "USA"
					 },
                     Ratings = new List<Rating>
					 {
                         new Rating
						 {
                             Description = "Cleanliness",
                             Value = 4
						 },
                         new Rating
                         {
                             Description = "On-time Payments",
                             Value = 5
                         },
                         new Rating
                         {
                             Description = "Support",
                             Value = 3
                         },
                         new Rating
                         {
                             Description = "Behavior",
                             Value = 3
                         },
                         new Rating
                         {
                             Description = "Recommendation",
                             Value = 4
                         },
                         new Rating
                         {
                             Description = "Reduced Noise",
                             Value = 1
                         },
                     }
				}
            };
        }

        public void OnGet()
        {
            
        }

		[BindProperty]
		public List<TenantReview> Reviews { get; set; }
	}
}
