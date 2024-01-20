using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECOPlantation.Data;
using ECOPlantation.Models;

namespace ECOPlantation.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int visitorId, int EventId)
        {
            var visitors = _context.Visitors.FirstOrDefault(x => x.VistorID == visitorId && x.InviteID == EventId);
            if (visitors == null)
            {
                Visitor visitor = new()
                {
                    VistorID = visitorId,
                    InviteID = EventId,
                };
                _context.Add(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Invites");
            }
            return RedirectToAction("Index", "Invites");
        }

    }
}
