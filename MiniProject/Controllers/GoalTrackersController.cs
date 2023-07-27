using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class GoalTrackersController : Controller
    {
        private readonly DnprojectContext _context;

        public GoalTrackersController(DnprojectContext context)
        {
            _context = context;
        }

        // GET: GoalTrackers
        public async Task<IActionResult> Index()
        {
              return _context.GoalTrackers != null ? 
                          View(await _context.GoalTrackers.ToListAsync()) :
                          Problem("Entity set 'DnprojectContext.GoalTrackers'  is null.");
        }

        // GET: GoalTrackers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoalTrackers == null)
            {
                return NotFound();
            }

            var goalTracker = await _context.GoalTrackers
                .FirstOrDefaultAsync(m => m.GoalId == id);
            if (goalTracker == null)
            {
                return NotFound();
            }

            return View(goalTracker);
        }

        // GET: GoalTrackers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoalTrackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoalId,Title,Discriptin,StartDate,IsComplete")] GoalTracker goalTracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goalTracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goalTracker);
        }

        // GET: GoalTrackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoalTrackers == null)
            {
                return NotFound();
            }

            var goalTracker = await _context.GoalTrackers.FindAsync(id);
            if (goalTracker == null)
            {
                return NotFound();
            }
            return View(goalTracker);
        }

        // POST: GoalTrackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoalId,Title,Discriptin,StartDate,IsComplete")] GoalTracker goalTracker)
        {
            if (id != goalTracker.GoalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goalTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalTrackerExists(goalTracker.GoalId))
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
            return View(goalTracker);
        }

        // GET: GoalTrackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoalTrackers == null)
            {
                return NotFound();
            }

            var goalTracker = await _context.GoalTrackers
                .FirstOrDefaultAsync(m => m.GoalId == id);
            if (goalTracker == null)
            {
                return NotFound();
            }

            return View(goalTracker);
        }

        // POST: GoalTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoalTrackers == null)
            {
                return Problem("Entity set 'DnprojectContext.GoalTrackers'  is null.");
            }
            var goalTracker = await _context.GoalTrackers.FindAsync(id);
            if (goalTracker != null)
            {
                _context.GoalTrackers.Remove(goalTracker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalTrackerExists(int id)
        {
          return (_context.GoalTrackers?.Any(e => e.GoalId == id)).GetValueOrDefault();
        }
    }
}
