using System.ComponentModel.DataAnnotations;

namespace CRR.Web.Models
{
	public class TenantReviewModel
	{
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

		public IFormFile Attachment { get; set; }

	}
}
