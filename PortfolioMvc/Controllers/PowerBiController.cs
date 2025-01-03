using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioMvc.Data;
using PortfolioMvc.Models;

namespace PortfolioMvc.Controllers
{
    public class PowerBiController : Controller
    {
        private readonly PortfolioMvcContext _context;

        public PowerBiController(PortfolioMvcContext context)
        {
            _context = context;
        }

        // GET: PowerBi
        public async Task<IActionResult> Index()
        {
            return View(await _context.PowerBi.ToListAsync());
        }

        // GET: PowerBi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerBi = await _context.PowerBi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerBi == null)
            {
                return NotFound();
            }

            return View(powerBi);
        }

        // GET: PowerBi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PowerBi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Image,ReleaseDate,Code,Context")] PowerBi powerBi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(powerBi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(powerBi);
        }

        // GET: PowerBi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerBi = await _context.PowerBi.FindAsync(id);
            if (powerBi == null)
            {
                return NotFound();
            }
            return View(powerBi);
        }

        // POST: PowerBi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image,ReleaseDate,Code,Context")] PowerBi powerBi)
        {
            if (id != powerBi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powerBi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerBiExists(powerBi.Id))
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
            return View(powerBi);
        }

        // GET: PowerBi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerBi = await _context.PowerBi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (powerBi == null)
            {
                return NotFound();
            }

            return View(powerBi);
        }

        // POST: PowerBi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var powerBi = await _context.PowerBi.FindAsync(id);
            if (powerBi != null)
            {
                _context.PowerBi.Remove(powerBi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerBiExists(int id)
        {
            return _context.PowerBi.Any(e => e.Id == id);
        }
    }
}
