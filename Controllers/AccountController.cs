using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity_2auth_mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_2auth_mvc.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<AppUser> _signManager;
		private readonly UserManager<AppUser> _userManager;

		public AccountController(SignInManager<AppUser> signManager, UserManager<AppUser> userManager)
		{
			_signManager = signManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
	
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new AppUser { UserName = model.UserName };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, Enums.Roles.Basic.ToString());
					await _signManager.SignInAsync(user, false);
					return RedirectToAction("Index", "Home");
				} 
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			return View();
		}
		
		[HttpGet]
		public async Task<IActionResult> Login(string returnUrl = "")
		{
			var model = new LoginViewModel { ReturnUrl = returnUrl };
			return View(model);
		}
		
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,
					false);
				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
					{
						return RedirectToAction(model.ReturnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
			}

			ModelState.AddModelError("", "Invalid login attemp.");
			return View(model);
		}

		public async Task<IActionResult> Logout()
		{
			await _signManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}


	}
}
