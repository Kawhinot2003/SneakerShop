using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SneakerShop.Controllers
{
	public class AuthorizationController : Controller
	{

		private UserManager<IdentityUser> _UserManager;
		private SignInManager<IdentityUser> _SignInManager;

		public AuthorizationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_UserManager = userManager;
			_SignInManager = signInManager;
		}

		public IActionResult Auth()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LoginInAccount()
		{
			string login = Request.Form["Login"],
				password = Request.Form["Password"];

			if (ModelState.IsValid)
			{
				var result = await _SignInManager.PasswordSignInAsync(login, password, true, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Неправильный логин и (или) пароль");
				}
			}

			return RedirectToAction("Login", "Authorization");
		}

		[HttpPost]
		public async Task<IActionResult> CreateAccount()
		{
			string email = Request.Form["Email"], 
				login = Request.Form["Login"],
				password = Request.Form["Password"];

			if (ModelState.IsValid)
			{
				var user = new IdentityUser()
				{
					Email = email,
					UserName = login
				};

				var result = await _UserManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await _SignInManager.SignInAsync(user, false);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return RedirectToAction("SignUp", "Authorization");
		}

	}
}