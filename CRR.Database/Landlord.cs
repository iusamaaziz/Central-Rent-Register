using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models
{
	public class Landlord : ApplicationUser
	{
		public Landlord()
		{
			PermanentAddress = string.Empty;
			About = string.Empty;
			Properties = new List<Property>();
		}

		public string About { get; set; }
		public string PermanentAddress { get; set; }

		public List<Property> Properties { get; set; }
	}
}
