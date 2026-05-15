using BPA205Pronia.Areas.Admin.ViewModels.Account.Admin;
using BPA205Pronia.DAL;
using BPA205Pronia.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPA205Pronia.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext db, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> AllUsers()
        {
            List<AppUser> users = await _db.Users
                .Where(u => !u.IsAdmin)
                .ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> AllAdmins()
        {
            List<AppUser> admins = await _db.Users
                .Where(u => u.IsAdmin)
                .ToListAsync();
            return View(admins);
        }
        public async Task<IActionResult> CreateAdmin()
        {
            ViewBag.Roles = await _db.Roles
                .Where(r => r.Name != "User")
                .ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminVM adminVM)
        {
            ViewBag.Roles = _db.Roles
                .Where(r => r.Name != "User")
                .ToList();
            AppUser user = new AppUser()
            {
                Name = "Admin",
                Surname = "Admin",
                UserName = adminVM.Email,
                Email = adminVM.Email,
                IsAdmin = true
            };
            await _userManager.CreateAsync(user, adminVM.Password);

            foreach (var role in ViewBag.Roles)
            {
                if (role is not null && await _roleManager.RoleExistsAsync(role.Name))
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
            }

            return RedirectToAction(nameof(AllAdmins));
        }
    }
}
