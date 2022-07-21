using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models
{
	public class Rating
	{
		public Rating()
		{
			Description = string.Empty;
			Value = 1;
		}

		public int Id { get; set; }
		public string Description { get; set; }
		public int Value { get; set; }
		public int? TenantReviewId { get; set; }

		public TenantReview? TenantReview { get; set; }
	}
}
