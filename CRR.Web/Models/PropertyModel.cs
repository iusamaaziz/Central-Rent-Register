using CRR.Models;

using System.ComponentModel.DataAnnotations;

namespace CRR.Web.Models
{
	public class PropertyModel
	{
		[Required(AllowEmptyStrings = false)]
		public string Type { get; set; }
		
		[Required]
		[MinLength(3)]
		public string Address { get; set; }
		
		[Required]
		[MinLength(3)]
		public string City { get; set; }
		
		[Required]
		[MinLength(2)]
		public string State { get; set; }
		
		[MinLength(3)]
		[Required]
		public string Country { get; set; }
	}
}
