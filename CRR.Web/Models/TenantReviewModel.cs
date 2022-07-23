using CRR.Models;

using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;

namespace CRR.Web.Models
{
	public class TenantReviewModel
	{
		public TenantReviewModel()
		{
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
		
		[Required]
		[MinLength(1)]
		public string TenantName { get; set; }
		
		[Required]
		public int PropertyId { get; set; }
		
		[Required]
		[MinLength(1)]
		public string StayDuration { get; set; }
		
		[Required]
		[MinLength(1)]
		public string TenantCNIC { get; set; }
		
		[Required]
		[MinLength(1)]
		public string Details { get; set; }

		[Optional(ErrorMessage = "Please select at least one attachment")]
		public IFormFileCollection Attachments { get; set; } = new FormFileCollection();

		public Rating[] Ratings { get; set; }
		
	}

	public class OptionalAttribute : RequiredAttribute
	{
		public override bool IsValid(object? value)
		{
			return true;
		}
	}
}
