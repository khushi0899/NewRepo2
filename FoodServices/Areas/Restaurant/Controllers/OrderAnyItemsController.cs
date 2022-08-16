using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodServices.Data;
using FoodServices.Models;

namespace FoodServices.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class OrderAnyItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderAnyItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant/OrderAnyItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderAnyItem.Include(o => o.Customer).Include(o => o.MenuItem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Restaurant/OrderAnyItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderAnyItem = await _context.OrderAnyItem
                .Include(o => o.Customer)
                .Include(o => o.MenuItem)
                .FirstOrDefaultAsync(m => m.OrderAnyItemId == id);
            if (orderAnyItem == null)
            {
                return NotFound();
            }

            return View(orderAnyItem);
        }

        // GET: Restaurant/OrderAnyItems/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "YourCard","CustomerName");
            ViewData["MenuId"] = new SelectList(_context.Menu, "ItemId", "ItemName");
            return View();
        }

        // POST: Restaurant/OrderAnyItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderAnyItemId,FoodQuantity,MenuId,CustomerId")] OrderAnyItem orderAnyItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderAnyItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", orderAnyItem.CustomerId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "ItemId", "ItemId", orderAnyItem.MenuId);
            return View(orderAnyItem);
        }

        // GET: Restaurant/OrderAnyItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderAnyItem = await _context.OrderAnyItem.FindAsync(id);
            if (orderAnyItem == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Address", orderAnyItem.CustomerId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "ItemId", "ItemId", orderAnyItem.MenuId);
            return View(orderAnyItem);
        }

        // POST: Restaurant/OrderAnyItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderAnyItemId,FoodQuantity,MenuId,CustomerId")] OrderAnyItem orderAnyItem)
        {
            if (id != orderAnyItem.OrderAnyItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderAnyItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderAnyItemExists(orderAnyItem.OrderAnyItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Address", orderAnyItem.CustomerId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "ItemId", "ItemId", orderAnyItem.MenuId);
            return View(orderAnyItem);
        }

        // GET: Restaurant/OrderAnyItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderAnyItem = await _context.OrderAnyItem
                .Include(o => o.Customer)
                .Include(o => o.MenuItem)
                .FirstOrDefaultAsync(m => m.OrderAnyItemId == id);
            if (orderAnyItem == null)
            {
                return NotFound();
            }

            return View(orderAnyItem);
        }

        // POST: Restaurant/OrderAnyItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderAnyItem = await _context.OrderAnyItem.FindAsync(id);
            _context.OrderAnyItem.Remove(orderAnyItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderAnyItemExists(int id)
        {
            return _context.OrderAnyItem.Any(e => e.OrderAnyItemId == id);
        }


        public IActionResult CreateSouthIndian()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "YourCard");
            ViewData["MenuId"] = new SelectList(_context.Menu.Where(e=>e.Category.CategoryName=="Chinese"), "ItemId", "ItemName");
            return View();
        }

        // POST: Restaurant/OrderAnyItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSouthIndian([Bind("OrderAnyItemId,FoodQuantity,MenuId,CustomerId")] OrderAnyItem orderAnyItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderAnyItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Address", orderAnyItem.CustomerId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "ItemId", "ItemId", orderAnyItem.MenuId);
            return View(orderAnyItem);
        }


        public IActionResult CreateItalian()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "YourCard");
            ViewData["MenuId"] = new SelectList(_context.Menu.Where(e => e.Category.CategoryName == "Italian"), "ItemId", "ItemName");
            return View();
        }

        // POST: Restaurant/OrderAnyItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItalian([Bind("OrderAnyItemId,FoodQuantity,MenuId,CustomerId")] OrderAnyItem orderAnyItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderAnyItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "Address", orderAnyItem.CustomerId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "ItemId", "ItemId", orderAnyItem.MenuId);
            return View(orderAnyItem);
        }
    }
}
