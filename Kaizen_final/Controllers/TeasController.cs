using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kaizen_final.Data;
using Kaizen_final.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kaizen_final.Controllers
{
    [Authorize]
    // //  var roles = new[] { "Admin", "Manager", "Employee" };

    public class TeasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeasController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> farmersearch(string farmersearch)
        {
            var applicationDbContext = from f in _context.Teas.Include(t => t.Farmer)
                                       select f;

            if (!String.IsNullOrEmpty(farmersearch))
            {
                applicationDbContext = applicationDbContext.Where(f => f.Farmer.farmerName.Contains(farmersearch));
            }

            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index(string searchString)
        {
            //var applicationDbContext = _context.Teas.Include(t => t.Farmer);
            //return View(await applicationDbContext.ToListAsync());
            var searchFarmer = from m in _context.Teas
                               select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchFarmer = searchFarmer.Where(s => s.TeaName.Contains(searchString));
            }

            return View(await searchFarmer.ToListAsync());

        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tea = await _context.Teas
                .Include(t => t.Farmer)
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (tea == null)
            {
                return NotFound();
            }

            return View(tea);
        }

        //  var roles = new[] { "Admin", "Manager", "Employee" };

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Create()
        {
            ViewData["farmerid"] = new SelectList(_context.Farmers, "farmerId", "farmerId");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaId,TeaName,TeaDescription,Price,Tea_Stock,picURL,farmerid")] Tea tea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["farmerid"] = new SelectList(_context.Farmers, "farmerId", "farmerId", tea.farmerid);
            return View(tea);
        }

        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tea = await _context.Teas.FindAsync(id);
            if (tea == null)
            {
                return NotFound();
            }
            ViewData["farmerid"] = new SelectList(_context.Farmers, "farmerId", "farmerId", tea.farmerid);
            return View(tea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaId,TeaName,TeaDescription,Price,Tea_Stock,picURL,farmerid")] Tea tea)
        {
            if (id != tea.TeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaExists(tea.TeaId))
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
            ViewData["farmerid"] = new SelectList(_context.Farmers, "farmerId", "farmerId", tea.farmerid);
            return View(tea);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tea = await _context.Teas
                .Include(t => t.Farmer)
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (tea == null)
            {
                return NotFound();
            }

            return View(tea);
        }

        // POST: Teas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tea = await _context.Teas.FindAsync(id);
            _context.Teas.Remove(tea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaExists(int id)
        {
            return _context.Teas.Any(e => e.TeaId == id);
        }
    }
}
