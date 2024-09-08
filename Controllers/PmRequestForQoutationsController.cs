using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrostbyteWebApp.Data.Services;

namespace FrostbyteWebApp.Models
{
    public class PmRequestForQoutationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PmRequestForQoutationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PmRequestForQoutations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PmrequestForQoutations.Include(p => p.PR);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PmRequestForQoutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmRequestForQoutation = await _context.PmrequestForQoutations
                .Include(p => p.PR)
                .FirstOrDefaultAsync(m => m.PmRequestForQoutationID == id);
            if (pmRequestForQoutation == null)
            {
                return NotFound();
            }

            return View(pmRequestForQoutation);
        }

        // GET: PmRequestForQoutations/Create
        public IActionResult Create()
        {
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode");
            return View();
        }

        // POST: PmRequestForQoutations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PmRequestForQoutationID,Description,PurchasingRequestID,PurcasingManagerID")] PmRequestForQoutation pmRequestForQoutation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pmRequestForQoutation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode", pmRequestForQoutation.PurchasingRequestID);
            return View(pmRequestForQoutation);
        }

        // GET: PmRequestForQoutations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmRequestForQoutation = await _context.PmrequestForQoutations.FindAsync(id);
            if (pmRequestForQoutation == null)
            {
                return NotFound();
            }
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode", pmRequestForQoutation.PurchasingRequestID);
            return View(pmRequestForQoutation);
        }

        // POST: PmRequestForQoutations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PmRequestForQoutationID,Description,PurchasingRequestID,PurcasingManagerID")] PmRequestForQoutation pmRequestForQoutation)
        {
            if (id != pmRequestForQoutation.PmRequestForQoutationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pmRequestForQoutation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PmRequestForQoutationExists(pmRequestForQoutation.PmRequestForQoutationID))
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
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode", pmRequestForQoutation.PurchasingRequestID);
            return View(pmRequestForQoutation);
        }

        // GET: PmRequestForQoutations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmRequestForQoutation = await _context.PmrequestForQoutations
                .Include(p => p.PR)
                .FirstOrDefaultAsync(m => m.PmRequestForQoutationID == id);
            if (pmRequestForQoutation == null)
            {
                return NotFound();
            }

            return View(pmRequestForQoutation);
        }

        // POST: PmRequestForQoutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pmRequestForQoutation = await _context.PmrequestForQoutations.FindAsync(id);
            if (pmRequestForQoutation != null)
            {
                _context.PmrequestForQoutations.Remove(pmRequestForQoutation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PmRequestForQoutationExists(int id)
        {
            return _context.PmrequestForQoutations.Any(e => e.PmRequestForQoutationID == id);
        }
    }
}
