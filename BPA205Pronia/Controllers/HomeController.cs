using BPA205Pronia.Models;
using BPA205Pronia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BPA205Pronia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Viewdata test item string";
            ViewData["Number"] = 100;
            int a = (int)ViewData["Number"];

            List<Product> products = new List<Product>
            {
        new Product
        {
        Id = 1,
        Title = "Monstera Deliciosa",
        ImageUrl = "1-1-270x300.jpg",
        Price = 45.99m
        },
        new Product
        {
        Id = 2,
        Title = "Fiddle Leaf Fig (Ficus Lyrata)",
        ImageUrl = "1-2-270x300.jpg",
        Price = 60.50m
    },
    new Product
    {
        Id = 3,
        Title = "Snake Plant (Sansevieria)",
        ImageUrl = "1-3-270x300.jpg",
        Price = 25.75m
    },
    new Product
    {
        Id = 4,
        Title = "Peace Lily (Spathiphyllum)",
        ImageUrl = "1-5-270x300.jpg",
        Price = 30.00m
    },
    new Product
    {
        Id = 5,
        Title = "Aloe Vera",
        ImageUrl = "1-4-270x300.jpg",
        Price = 15.20m
    },
    new Product
    {
        Id = 6,
        Title = "Areca Palm",
        ImageUrl = "1-5-270x300.jpg",
        Price = 55.90m
    },
    new Product
    {
        Id = 7,
        Title = "Calathea Orbifolia",
        ImageUrl = "1-7-270x300.jpg",
        Price = 40.00m
    },
    new Product
    {
        Id = 8,
        Title = "Rubber Plant (Ficus Elastica)",
        ImageUrl = "1-8-270x300.jpg",
        Price = 35.45m
    },
       new Product
    {
        Id = 9,
        Title = "Aloe Vera",
        ImageUrl = "1-4-270x300.jpg",
        Price = 15.20m
    }
};

            List<Slider> sliders = new List<Slider>
            {
                new Slider
                {
                    Id = 1,
                    Discount = 64,
                    Title = "Kenan",
                    Desc = "Derdli",
                    ImageUrl = "1-1-524x617.png"
                },
                new Slider
                {
                    Id = 2,
                    Discount = 63,
                    Title = "Omer",
                    Desc = "Derdsiz",
                    ImageUrl = "1-1-570x633.jpg"
                },
                new Slider
                {
                    Id = 1,
                    Discount = 64,
                    Title = "Rovshen",
                    Desc = "Lenkeranski",
                    ImageUrl = "1-1-524x617.png"
                },
            };

            HomeVM vM = new HomeVM()
            {
                Products = products,
                Sliders = sliders
            };
            return View(vM);
        }
    }
}
