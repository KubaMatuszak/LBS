using LBS.Models;
using LBS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LBS.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<LBSUser> _signInManager;
		private readonly UserManager<LBSUser> _userManager;
        public AccountController(SignInManager<LBSUser> signInManager, UserManager<LBSUser> userManager)
        {
            _signInManager = signInManager;
			_userManager = userManager;
        }
        public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			
				var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!,model.RememberMe,false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Nieprawidłowy login lub hasło");
					return View(model);
				}
			
			
			
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if(ModelState.IsValid) 
			{
				LBSUser user = new()
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,
					UserName=model.Username

				};
				var result = await _userManager.CreateAsync(user,model.Password!);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, false);
					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors) 
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View();
		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
