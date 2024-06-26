﻿using LBS.Data;
using LBS.Models;
using LBS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LBS.Controllers
{
	[Authorize]
	public class LessonController : Controller
	{
		private readonly LessonDbContext _context;
		private readonly UserManager<LBSUser> _userManager;
		public LessonController(LessonDbContext context, UserManager<LBSUser> user)
		{
			_context = context;
			_userManager = user;
		}

		
		public IActionResult Add()
		{
			
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(LessonViewModel vmodel) 
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			LBSUser loggeduser = await _userManager.FindByIdAsync(userId);

			Lesson lesson = new()
			{
				LessonDate = vmodel.LessonDate,
				LessonLength = vmodel.LessonLength,
				LessonTime = vmodel.LessonTime,
				StudentFirstName = loggeduser.FirstName,
				StudentLastName = loggeduser.LastName

			};
			if(lesson.LessonDate.DayOfWeek.ToString()=="Saturday" || lesson.LessonDate.DayOfWeek.ToString() == "Sunday")
			{
				ModelState.AddModelError("", "Nauczyciel nie pracuje w wybrany dzień");
				return View(vmodel);
			}
			var dates = _context.lessons.ToList();
			foreach (var date in dates)
			{
				if (date.LessonDate == lesson.LessonDate)
				{
					if (date.LessonTime == lesson.LessonTime || Math.Abs((date.LessonTime - lesson.LessonTime).TotalMinutes) < lesson.LessonLength)
					{
						ModelState.AddModelError("", "Termin jest już zajęty");
						return View(vmodel);
					}

				}
			}
			_context.Add(lesson);
			_context.SaveChanges();

			return RedirectToAction("MyLessons");
		}
		public async Task<IActionResult> MyLessons()
		{
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            LBSUser loggeduser = await _userManager.FindByIdAsync(userId);
			
			
			if (loggeduser.UserName!="Admin")
			{
				var lessons = _context.lessons.Where(x => x.StudentFirstName == loggeduser.FirstName && x.StudentLastName == loggeduser.LastName).ToList();
				return View(lessons);
			}
            var adminlessons = _context.lessons.ToList();
			return View(adminlessons);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{

			var lesson = _context.lessons.Find(id);
			return View(lesson);

		}
		[HttpPost]
		public async Task<IActionResult> Edit (Lesson lesson)
		{
			if (lesson.LessonDate.DayOfWeek.ToString() == "Saturday" || lesson.LessonDate.DayOfWeek.ToString() == "Sunday")
			{
				ModelState.AddModelError("", "Nauczyciel nie pracuje w wybrany dzień");
				return View(lesson);
			}
			
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			LBSUser loggeduser = await _userManager.FindByIdAsync(userId);
			lesson.StudentLastName = loggeduser.FirstName;
			lesson.StudentFirstName = loggeduser.FirstName;
			_context.lessons.Update(lesson);
			await _context.SaveChangesAsync();
			return RedirectToAction("MyLessons");
		}
		[HttpGet]
		public IActionResult Delete (int id) 
		{
			var item = _context.lessons.Find(id);
			_context.lessons.Remove(item);
			_context.SaveChanges();
			return RedirectToAction("MyLessons");
		}
	}
}
