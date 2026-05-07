using BPA205Pronia.Areas.Admin.ViewModels.Review;
using BPA205Pronia.DAL;
using BPA205Pronia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPA205Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewController : Controller
    {
        private readonly AppDbContext _db;
        public ReviewController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Review> reviews = await _db.Reviews
                .Include(r => r.Product)
                .ToListAsync();
            return View(reviews);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Products = await _db.Products.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewVM reviewVM)
        {
            Review review = new Review()
            {
                UserName = reviewVM.UserName,
                Comment = reviewVM.Comment,
                ProductId = reviewVM.ProductId,
            };
            if (!ModelState.IsValid) return View();
            await _db.Reviews.AddAsync(review);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Review review = await _db.Reviews.FindAsync(id);
            review.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Review review = await _db.Reviews.FindAsync(id);
            review.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            Review review = await _db.Reviews.FindAsync(id);
            UpdateReviewVM reviewVM = new UpdateReviewVM()
            {
                Id = review.Id,
                UserName = review.UserName,
                Comment = review.Comment,
                ProductId = review.ProductId
            };
            ViewBag.Products = await _db.Products.ToListAsync();
            return View(reviewVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateReviewVM reviewVM)
        {
            Review oldReview = await _db.Reviews.FindAsync(reviewVM.Id);
            oldReview.UserName = reviewVM.UserName;
            oldReview.Comment = reviewVM.Comment;
            oldReview.ProductId = reviewVM.ProductId;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
