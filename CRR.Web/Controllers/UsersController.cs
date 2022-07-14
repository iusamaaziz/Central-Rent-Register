using CRR.Models;
using CRR.Web.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRR.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		public readonly ApplicationDbContext _context;
		public readonly UserManager<ApplicationUser> _userManager;
		public readonly RoleManager<IdentityRole> _roleManager;

		public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}

		[HttpPost("addto/{role}")]
		public async Task<IActionResult> AddToRoleAsync([FromRoute] string role, Landlord landlord)
		{
			var user = await _userManager.FindByIdAsync(landlord.Id);

			if (user == null) return BadRequest("User does not exist.");

			if (!await _roleManager.RoleExistsAsync(role))
				await _roleManager.CreateAsync(new IdentityRole { Name = role });
			
			if (await _userManager.IsInRoleAsync(user, role))
			{
				return BadRequest("User is already in the role.");
			}

			await _userManager.AddToRoleAsync(user, role);

			return Ok();
		}
	}
}
