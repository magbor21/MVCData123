using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCData123.Data;
using MVCData123.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MVCData123.Controllers
{
    public class IDUsersController : Controller
    {
        private readonly PersonContext _personContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IDUsersController(PersonContext personContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _personContext = personContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admins()
        {
            //var adminrole = _roleManager.awa Roles.FirstOrDefault(r=>r.Name == "Admin");
            var adminView = await _userManager.GetUsersInRoleAsync("Admin");
            await Task.WhenAll();
            return View("Admins",adminView);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Users()
        {
            var adminView = await _userManager.GetUsersInRoleAsync("Admin");
            var userView = _userManager.Users.ToList();
            await Task.WhenAll();

            var usersNotInRole = userView.Where(user => !adminView.Any(userInRole => userInRole == user));

            return View("Users", usersNotInRole);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminAdd(ApplicationUser applicationUser)
        {
            var user = await _userManager.FindByIdAsync(applicationUser.Id);
            await _userManager.AddToRoleAsync(user, "Admin");

            return RedirectToAction("Admins");
        }
    }
}
