using System.ComponentModel.DataAnnotations;

namespace CRR.Web.Models
{
	public class LandlordModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Invalid address")]
		public string PermanentAdress { get; set; } = string.Empty;
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please tell us a little about yourself")]
		[MinLength(5, ErrorMessage = "Atleast 5 characters")]
		public string About { get; set; } = string.Empty;
	}
}
