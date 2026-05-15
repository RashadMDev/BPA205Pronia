using BPA205Pronia.Areas.Admin.ViewModels.Role;
using BPA205Pronia.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPA205Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class RoleController : Controller
    {
        private readonly AppDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(AppDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            List<IdentityRole> roles = await _db.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleVM roleVM)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = roleVM.Name
            };
            await _roleManager.CreateAsync(role);

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Edit(string? id)
        {
            IdentityRole role = await _db.Roles.FindAsync(id);
            EditRoleVM roleVM = new EditRoleVM()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(roleVM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleVM roleVM)
        {
            IdentityRole role = await _db.Roles.FindAsync(roleVM.Id);
            role.Name = roleVM.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
