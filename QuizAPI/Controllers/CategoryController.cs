#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Context;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public CategoryController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        [Route("GetCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var Categories = await (_context.Category
               .Select(x => new
               {
                   CategoryId = x.CategoryID,
                   CategoryName = x.CategoryName
               })
               ).ToListAsync();


            return Ok(Categories);
        }

//        // GET: Category/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Category_1 == null)
//            {
//                return NotFound();
//            }

//            var category = await _context.Category_1
//                .FirstOrDefaultAsync(m => m.CategoryID == id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            return View(category);
//        }

//        // GET: Category/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Category/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName")] Category category)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(category);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(category);
//        }

//        // GET: Category/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Category_1 == null)
//            {
//                return NotFound();
//            }

//            var category = await _context.Category_1.FindAsync(id);
//            if (category == null)
//            {
//                return NotFound();
//            }
//            return View(category);
//        }

//        // POST: Category/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName")] Category category)
//        {
//            if (id != category.CategoryID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(category);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CategoryExists(category.CategoryID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(category);
//        }

//        // GET: Category/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Category_1 == null)
//            {
//                return NotFound();
//            }

//            var category = await _context.Category_1
//                .FirstOrDefaultAsync(m => m.CategoryID == id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            return View(category);
//        }

//        // POST: Category/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Category_1 == null)
//            {
//                return Problem("Entity set 'QuizDbContext.Category_1'  is null.");
//            }
//            var category = await _context.Category_1.FindAsync(id);
//            if (category != null)
//            {
//                _context.Category_1.Remove(category);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CategoryExists(int id)
//        {
//            return (_context.Category_1?.Any(e => e.CategoryID == id)).GetValueOrDefault();
//        }
    }
}
