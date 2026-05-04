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
            if (!ModelState.IsValid) return View();
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

        public IActionResult Update(int id)
        {
            Slider slider = _db.Sliders.Find(id);
            return View(slider);
        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider oldSlider = _db.Sliders.Find(slider.Id);
            oldSlider.Title = slider.Title;
            oldSlider.Discount = slider.Discount;
            oldSlider.Desc = slider.Desc;
            oldSlider.ImageUrl = slider.ImageUrl;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
