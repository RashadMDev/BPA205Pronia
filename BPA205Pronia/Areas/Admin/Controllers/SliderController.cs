using BPA205Pronia.DAL;
using BPA205Pronia.Models;
using Microsoft.AspNetCore.Mvc;

namespace BPA205Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        public SliderController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            _db.Sliders.Add(slider);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        #region Hard Delete
        //[HttpPost]
        //public IActionResult Delete(int? id)
        //{
        //    Slider slider = _db.Sliders.Find(id);
        //    _db.Sliders.Remove(slider);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //} 
        #endregion

        // Soft Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Slider slider = _db.Sliders.Find(id);
            slider.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Restore
        [HttpPost]
        public IActionResult Restore(int id)
        {
            Slider slider = _db.Sliders.Find(id);
            slider.IsDeleted = false;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
