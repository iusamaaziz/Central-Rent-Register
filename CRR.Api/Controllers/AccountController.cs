using CRR.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CRR.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUserStore<ApplicationUser> _userStore;
		private readonly IUserEmailStore<ApplicationUser> _emailStore;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			IUserStore<ApplicationUser> userStore,
			//IUserEmailStore<ApplicationUser> emailStore,
			SignInManager<ApplicationUser> signInManager
			)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_userStore = userStore;
			//_emailStore = emailStore;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginParameters model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

			if (result.Succeeded)
				return Ok();
			else return BadRequest("Invalid login attempt");
		}

        [HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterParameters model)
        {
			var user = CreateUser();
			user.Email = model.Email;
			await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
				return Ok(result);
			else return BadRequest(result.Errors.Select(s => s.Description));
		}

		private ApplicationUser CreateUser()
		{
			try
			{
				return Activator.CreateInstance<ApplicationUser>();
			}
			catch
			{
				throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
					$"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
					$"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
			}
		}

		private IUserEmailStore<ApplicationUser> GetEmailStore()
		{
			if (!_userManager.SupportsUserEmail)
			{
				throw new NotSupportedException("The default UI requires a user store with email support.");
			}
			return (IUserEmailStore<ApplicationUser>)_userStore;
		}
	}
}
