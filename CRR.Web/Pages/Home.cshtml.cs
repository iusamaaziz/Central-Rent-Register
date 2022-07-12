using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRR.Web.Pages
{
	[Authorize]
    public class HomeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
