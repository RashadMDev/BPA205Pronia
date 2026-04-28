using BPA205Pronia.DAL;
using BPA205Pronia.Models;
using BPA205Pronia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPA205Pronia.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();
            List<Product> products = _db.Products
                .Include(p => p.Images)
                .ToList();

            HomeVM vM = new HomeVM()
            {
                Products = products,
                Sliders = sliders
            };
            return View(vM);
        }
    }
}
