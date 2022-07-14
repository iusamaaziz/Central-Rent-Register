using CRR.Models;
using CRR.Web.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRR.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PropertiesController
	{
		private readonly ApplicationDbContext _context;

		public PropertiesController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("{userId}")]
		public async Task<Property[]> GetAsync([FromRoute] string userId)
		{
			return await _context.Properties.Where(p => p.ApplicationUserId == userId).ToArrayAsync();
		}

		[HttpPost("upsert")]
		public async Task<HttpResponseMessage> UpsertAsync([FromBody] Property property)
		{
			var prop = await _context.Properties.FirstOrDefaultAsync(p => p.Id == property.Id);

			if (prop != null)
			{
				//update
				prop.Address = property.Address;
				prop.City = property.City;
				prop.State = property.State;
				prop.Country = property.Country;
				prop.Type = property.Type;

				_context.Entry(prop).State = EntityState.Modified;
			}
			else
			{
				_context.Properties.Add(property);
			}

			await _context.SaveChangesAsync();

			return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
		}
	}
}
