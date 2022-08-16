using FoodServices.Data;
using FoodServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FoodServices.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class CascadeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CascadeController(ApplicationDbContext context)
        {
            this._context = context;
        }
       
        public IActionResult Index()
        {
            
            return View("Hello World");
        }

      
    }
}
