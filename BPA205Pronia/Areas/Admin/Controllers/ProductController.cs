using BPA205Pronia.Areas.Admin.ViewModels.Product;
using BPA205Pronia.DAL;
using BPA205Pronia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPA205Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .Include(p => p.Reviews)
                .ToListAsync();
            return View(products);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            Product product = new Product()
            {
                Title = productVM.Title,
                Description = productVM.Description,
                Price = productVM.Price,
                SKU = productVM.SKU.ToUpper().Trim(),
            };
            if (productVM.CategoryIds is not null)
            {
                product.Categories = await _db.Categories
                    .Where(c => productVM.CategoryIds.Contains(c.Id))
                    .ToListAsync();
            }
            if (productVM.TagIds is not null)
            {
                product.Tags = await _db.Tags.Where(t => productVM.TagIds.Contains(t.Id)).ToListAsync();
            }

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            Product product = await _db.Products.FindAsync(id);
            product.IsDeleted = false;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();
            Product product = await _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);

            UpdateProductVM productVM = new UpdateProductVM()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryIds = product.Categories.Select(c => c.Id).ToList(),
                TagIds = product.Tags.Select(t => t.Id).ToList(),
            };

            return View(productVM);
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM productVM)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Tags = await _db.Tags.ToListAsync();

            Product oldProduct = await _db.Products
                .Include(p => p.Categories)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == productVM.Id);

            oldProduct.Id = productVM.Id;
            oldProduct.Title = productVM.Title;
            oldProduct.Description = productVM.Description;
            oldProduct.Price = productVM.Price;

            oldProduct.Categories.Clear();
            if (productVM.CategoryIds is not null)
            {
                oldProduct.Categories = await _db.Categories
                    .Where(c => productVM.CategoryIds.Contains(c.Id))
                    .ToListAsync();
            }

            oldProduct.Tags.Clear();
            if (productVM.TagIds is not null)
            {
                oldProduct.Tags = await _db.Tags.Where(t => productVM.TagIds.Contains(t.Id)).ToListAsync();
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
