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
		
		public DateTime Date { get; set; }
		public double RatingOverview => Ratings.Average(r => r.Value);
		public string LandlordId { get; set; }
		public int PropertyId { get; set; }
		

		public Landlord Landlord { get; set; }
		public Property Property { get; set; }
		public List<Rating> Ratings { get; set; }
	}
}
