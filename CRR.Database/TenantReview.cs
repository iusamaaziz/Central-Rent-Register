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
			Attachments = new List<Attachment>();
		}

		public int Id { get; set; }
		public string TenantName { get; set; }
		public string TenantCNIC { get; set; }
		public string StayDuration { get; set; }
		public string Details { get; set; }
		public DateTime Date { get; set; }
		//public double RatingOverview => Ratings.Count > 0 ? Math.Round(Ratings.Average(r => r.Value), 0, MidpointRounding.ToPositiveInfinity) : 0;
		
		public string ApplicationUserId { get; set; }
		public int PropertyId { get; set; }

		public ApplicationUser? ApplicationUser { get; set; }
		public Property? Property { get; set; }
		public List<Attachment> Attachments { get; set; }
		public List<Rating> Ratings { get; set; }
	}
}
