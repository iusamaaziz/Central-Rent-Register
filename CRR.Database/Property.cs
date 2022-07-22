using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models
{
	public class Property
	{
		public int Id { get; set; }
		public string? Type { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
		
		public string? ApplicationUserId { get; set; }
	}
}
