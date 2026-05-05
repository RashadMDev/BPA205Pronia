using BPA205Pronia.DAL;
using BPA205Pronia.Models;
using BPA205Pronia.Utilities.Image;
using Microsoft.AspNetCore.Mvc;

namespace BPA205Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Get Sliders
        public IActionResult Index()
        {
            List<Slider> sliders = _db.Sliders.ToList();
            return View(sliders);
        }
        #endregion

        #region Create Slider
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!slider.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File must be an image");
                return View();
            }
            if (!(slider.ImageFile.Length < 2 * 1024 *1024))
            {
                ModelState.AddModelError("ImageFile", "File size must be maximum 2MB");
                return View();
            }

            slider.ImageUrl = slider.ImageFile.SaveImage(_env, "uploads/sliders");
            if (!ModelState.IsValid) return View();
            _db.Sliders.Add(slider);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

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

        #region Soft Delete and Restore

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
        #endregion

        #region Update Slider
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
        #endregion
    }
}
