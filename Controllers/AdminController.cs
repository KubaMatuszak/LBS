using LBS.AdminSettings;
using LBS.Models;
using LBS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LBS.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private readonly UserManager<LBSUser> _userManager;

		public AdminController(UserManager<LBSUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Avaliable()
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			LBSUser loggeduser = await _userManager.FindByIdAsync(userId);
			if(loggeduser.UserName != "Admin")
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Avaliable(AdminSettingsViewModel viewmodel)
		{
			AdminSettings.AdminSettings.minTime = viewmodel.minTime;
			AdminSettings.AdminSettings.maxTime = viewmodel.maxTime;

			return RedirectToAction("Index", "Home");
		}

	}
}
