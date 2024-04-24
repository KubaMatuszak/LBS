using LBS.Models;
using LBS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LBS.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<LBSUser> _signInManager;
        public AccountController(SignInManager<LBSUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if(ModelState.IsValid) 
			{
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,model.RememberMe,false);
				if(result.Succeeded) 
				{
				return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Nieudana próba logowania");
				return View(model);
			}
			
			return View(model);
		}
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult Logout()
		{
			return View();
		}
	}
}
