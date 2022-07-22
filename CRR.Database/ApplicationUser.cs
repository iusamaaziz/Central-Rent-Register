using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRR.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			About = string.Empty;
			PermanentAddress = string.Empty;
		}

		public string About { get; set; }
		public string PermanentAddress { get; set; }
	}
}
