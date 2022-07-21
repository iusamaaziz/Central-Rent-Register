using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public byte[]? Content { get; set; }
		public int? TenantReviewId { get; set; }

        public TenantReview? TenantReview { get; set; }
	}
}
