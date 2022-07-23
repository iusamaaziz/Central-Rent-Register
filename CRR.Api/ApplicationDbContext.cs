using CRR.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRR.Api
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		//public DbSet<Landlord> Landlords { get; set; }
		//public DbSet<Tenant> Tenants { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<TenantReview> TenantReviews { get; set; }
		public DbSet<Rating> Ratings { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			//builder.Entity<TenantReview>(e =>
			//{
			//	e.Ignore(r => r.RatingOverview);
			//});

			base.OnModelCreating(builder);
		}

		public DbSet<CRR.Models.Attachment>? Attachment { get; set; }

	}
}