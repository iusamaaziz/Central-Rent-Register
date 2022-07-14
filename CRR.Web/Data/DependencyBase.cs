using CRR.Models;

using Microsoft.AspNetCore.Identity;

namespace CRR.Web.Data
{
	public class DependencyBase
	{
		public readonly ApplicationDbContext _context;
		public readonly UserManager<ApplicationUser> _userManager;
		public readonly RoleManager<IdentityRole> _roleManager;

		public DependencyBase(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}
	}
}
