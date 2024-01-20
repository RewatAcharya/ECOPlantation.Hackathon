using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECOPlantation.Data;
using ECOPlantation.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECOPlantation.Controllers
{
    [Authorize]
    public class FertilizersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FertilizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fertilizers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fertilizers.Include(f => f.UserFertilizer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fertilizers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fertilizers = await _context.Fertilizers
                .Include(f => f.UserFertilizer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fertilizers == null)
            {
                return NotFound();
            }

            return View(fertilizers);
        }

        // GET: Fertilizers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fertilizers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fertilizers fertilizers)
        {
            fertilizers.MsgDate = fertilizers.CreatedAt.AddDays(5);

            _context.Add(fertilizers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Fertilizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fertilizers = await _context.Fertilizers.FindAsync(id);
            if (fertilizers == null)
            {
                return NotFound();
            }
            return View(fertilizers);
        }

        // POST: Fertilizers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fertilizers fertilizers)
        {
            if (id != fertilizers.Id)
            {
                return NotFound();
            }
            fertilizers.UpdatedDate = DateTime.UtcNow;

            try
            {
                _context.Update(fertilizers);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FertilizersExists(fertilizers.Id))
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

        // GET: Fertilizers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fertilizers = await _context.Fertilizers
                .Include(f => f.UserFertilizer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fertilizers == null)
            {
                return NotFound();
            }

            return View(fertilizers);
        }

        // POST: Fertilizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fertilizers = await _context.Fertilizers.FindAsync(id);
            if (fertilizers != null)
            {
                _context.Fertilizers.Remove(fertilizers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FertilizersExists(int id)
        {
            return _context.Fertilizers.Any(e => e.Id == id);
        }
    }
}
