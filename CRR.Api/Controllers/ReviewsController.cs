using CRR.Api;
using CRR.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRR.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ReviewsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var revs = await _context.TenantReviews
				//.Include(r => r.ApplicationUser)
				.Include(r => r.Property)
				.ToArrayAsync();
			//return Ok(await _context.TenantReviews
			//.Include(r => r.ApplicationUser)
			//.Include(r => r.Property)
			//.Include(r => r.Ratings)
			//.Include(r => r.Attachments)
			//.ToListAsync());

			return Ok(revs);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddReviewAsync([FromBody] TenantReview model)
		{
			try
			{
				await _context.TenantReviews.AddAsync(model);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

	}
}
