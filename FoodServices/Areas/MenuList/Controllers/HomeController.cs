using FoodServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


using System.Linq;
using FoodServices.Areas.MenuList.ViewModels;
using FoodServices.Models;

namespace FoodServices.Areas.MenuList.Controllers
{
    [Area("MenuList")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            categories.AddRange(new SelectList(_context.Category, "CategoryId", "CategoryName"));
            ViewData["CategoryId"] = categories.ToArray();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CategoryId")] ShowMenuViewModel model)
        {
            var items = _context.Menu.Where(m => m.CategoryId == model.CategoryId);

            model.MenuItems = items.ToList();
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");

            return View("Index", model);
        }
        public IActionResult AddToCart(int? id, [Bind("CategoryId", "Quantity")] ShowMenuViewModel model)
        {
            if (id.HasValue)
            {
                int menuItemId = id.Value;
            }
            return RedirectToAction("Index");
        }
    }
}

