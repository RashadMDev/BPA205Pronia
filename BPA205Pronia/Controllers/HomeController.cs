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
            List<Slider> sliders = _db.Sliders
                .Where<Slider>(s => !s.IsDeleted)
                .ToList();
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
        public IActionResult Details(int id)
        {
           Product singleProduct = _db.Products
                .Include(p => p.Images)
                .Include(p => p.Reviews)
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == id);
            return View(singleProduct);
        }
    }
}
