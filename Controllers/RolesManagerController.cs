using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity_2auth_mvc.Enums;

namespace identity_2auth_mvc.Controllers
{
	[Authorize(Roles = "SuperAdmin")]
	public class RolesManagerController: Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		public RolesManagerController(RoleManager<IdentityRole> roleManager) 
		{
			_roleManager = roleManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return View(roles);
		}

		[HttpPost]
		public async Task<IActionResult> AddRole(string roleName)
		{
			if (roleName != string.Empty)
			{
				var role = await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
			}

			return RedirectToAction("Index");
		} 
	} 
} 