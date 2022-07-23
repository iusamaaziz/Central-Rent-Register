using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRR.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InsightsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public InsightsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			int reviews = await _context.TenantReviews.CountAsync();
			int users = await _context.Users.CountAsync();
			int properties = await _context.Properties.CountAsync();

			return Ok(new
			{
				reviews,
				users,
				properties
			});
		}
	}
}
