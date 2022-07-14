using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models
{
	public class TenantReview
	{
		public TenantReview()
		{
			Ratings = new List<Rating>();
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public double RatingOverview => Ratings.Average(r => r.Value);
		
		public string ApplicationUserId { get; set; }
		public int PropertyId { get; set; }

		public ApplicationUser ApplicationUser { get; set; }
		public Property Property { get; set; }
		public List<Rating> Ratings { get; set; }
	}
}
