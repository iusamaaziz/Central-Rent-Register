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

		[HttpGet("search/{search}")]
		public async Task<IActionResult> Get([FromRoute] string search)
		{
			var revs = await _context.TenantReviews
				.Include(r => r.ApplicationUser)
				.Include(r => r.Property)
				.Include(r => r.Attachments)
				.Include(r => r.Ratings)
				.Where(r => r.TenantName.Contains(search)
				|| r.TenantCNIC.Contains(search)
				|| r.Property.City.StartsWith(search)
				|| r.Property.Address.StartsWith(search)
				|| r.Property.State.StartsWith(search)
				|| r.Property.Country.StartsWith(search)
				)
				.ToArrayAsync();

			return Ok(revs);
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var revs = await _context.TenantReviews
				.Include(r => r.ApplicationUser)
				.Include(r => r.Property)
				.Include(r => r.Attachments)
				.Include(r => r.Ratings)
				.ToArrayAsync();

			return Ok(revs);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] int id)
		{
			var review = await _context.TenantReviews
				.Include(r => r.ApplicationUser)
				.Include(r => r.Property)
				.Include(r => r.Attachments)
				.Include(r => r.Ratings)
				.FirstAsync(r => r.Id == id);

			if (review == null) return NotFound();
			return Ok(review);
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
