using Microsoft.AspNetCore.Mvc;

namespace LBS.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
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
