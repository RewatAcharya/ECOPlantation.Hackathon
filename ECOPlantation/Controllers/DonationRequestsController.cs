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
    public class DonationRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;


        public DonationRequestsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: DonationRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonationRequests.Include(d => d.RequestedUser).Where(x => x.Donated == false);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DonationRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationRequest = await _context.DonationRequests
                .Include(d => d.RequestedUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donationRequest == null)
            {
                return NotFound();
            }

            return View(donationRequest);
        }

        // GET: DonationRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonationRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonationRequest donationRequest)
        {
       
                string filename = Guid.NewGuid() + Path.GetExtension(donationRequest.FileUpload.FileName);
                string imgpath = Path.Combine(_env.WebRootPath, "Images/DonationRequest/", filename);
                using (FileStream streamread = new FileStream(imgpath, FileMode.Create))
                {
                    donationRequest.FileUpload.CopyTo(streamread);
                }
                donationRequest.RequestPhotoURL = filename;
                _context.Add(donationRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DonationRequests");
            
        }

        // GET: DonationRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationRequest = await _context.DonationRequests.FindAsync(id);
            if (donationRequest == null)
            {
                return NotFound();
            }
            ViewData["RequestedBy"] = new SelectList(_context.ApplicationUsers, "Id", "Id", donationRequest.RequestedBy);
            return View(donationRequest);
        }

        // POST: DonationRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestPhotoURL,Content,RequestedBy,Id,CreatedAt")] DonationRequest donationRequest)
        {
            if (id != donationRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donationRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationRequestExists(donationRequest.Id))
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
            ViewData["RequestedBy"] = new SelectList(_context.ApplicationUsers, "Id", "Id", donationRequest.RequestedBy);
            return View(donationRequest);
        }

        // GET: DonationRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationRequest = await _context.DonationRequests
                .Include(d => d.RequestedUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donationRequest == null)
            {
                return NotFound();
            }

            return View(donationRequest);
        }

        // POST: DonationRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donationRequest = await _context.DonationRequests.FindAsync(id);
            if (donationRequest != null)
            {
                _context.DonationRequests.Remove(donationRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationRequestExists(int id)
        {
            return _context.DonationRequests.Any(e => e.Id == id);
        }

        public IActionResult Payments(int id)
        {
            ViewBag.DonationId = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Payments(DonationPayment donationPayment) 
        {
            donationPayment.Id = 0;
            _context.Add(donationPayment);
            await _context.SaveChangesAsync();


            var requested = _context.DonationRequests.FirstOrDefault(x => x.Id == donationPayment.RequestedDonation);
            if (requested != null)
            {
                requested.Donated = true;
                _context.DonationRequests.Update(requested);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
