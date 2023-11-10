using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProjectMarket.Client.Models;
using PetProjectMarket.Client.Services.Account;
using PetProjectMarket.Shared.ModelDTO.Account;

namespace PetProjectMarket.Client.Controllers
{
	public class AccountController : Controller
	{
		private readonly IHttpClientServiceAccountImplementation serviceAccount;

		public AccountController(IHttpClientServiceAccountImplementation _serviceAccount) => serviceAccount = _serviceAccount;

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register() => View();

		[HttpPost]
		public async Task<IActionResult> Register(UserRegistration userReg)
		{
			if (!ModelState.IsValid || userReg is null)
				return View(userReg);

			await serviceAccount.Register(userReg);

			return View(nameof(HomeController.HomePage), "Home");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Login(string returnUrl)
		{
			ViewData["returnUrl"] = returnUrl;
			await Task.Delay(0);
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
		{
			if (!ModelState.IsValid || userLogin is null)
				return View(userLogin);

			await serviceAccount.Login(userLogin);

			return RedirectToLocal(returnUrl: returnUrl);
		}
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await serviceAccount.Logout();

			return View(nameof(HomeController.HomePage), "Home");
		}
		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);

			return View(nameof(HomeController.HomePage), "Home");
		}
		private IActionResult Error(ErrorViewModel error) => View(error);
	}
}
