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
    public class SendPmRequestForQuotationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendPmRequestForQuotationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SendPmRequestForQuotations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SendPmrequestForQuotations.Include(s => s.S);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SendPmRequestForQuotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendPmRequestForQuotation = await _context.SendPmrequestForQuotations
                .Include(s => s.S)
                .FirstOrDefaultAsync(m => m.SendPmRequestForQoutationID == id);
            if (sendPmRequestForQuotation == null)
            {
                return NotFound();
            }

            return View(sendPmRequestForQuotation);
        }

        // GET: SendPmRequestForQuotations/Create
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1");
            return View();
        }

        // POST: SendPmRequestForQuotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendPmRequestForQoutationID,DateCreated,DueDate,ResponseLocation,PmRequestForQuotationID,SupplierID")] SendPmRequestForQuotation sendPmRequestForQuotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sendPmRequestForQuotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendPmRequestForQuotation.SupplierID);
            return View(sendPmRequestForQuotation);
        }

        // GET: SendPmRequestForQuotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendPmRequestForQuotation = await _context.SendPmrequestForQuotations.FindAsync(id);
            if (sendPmRequestForQuotation == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendPmRequestForQuotation.SupplierID);
            return View(sendPmRequestForQuotation);
        }

        // POST: SendPmRequestForQuotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendPmRequestForQoutationID,DateCreated,DueDate,ResponseLocation,PmRequestForQuotationID,SupplierID")] SendPmRequestForQuotation sendPmRequestForQuotation)
        {
            if (id != sendPmRequestForQuotation.SendPmRequestForQoutationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendPmRequestForQuotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendPmRequestForQuotationExists(sendPmRequestForQuotation.SendPmRequestForQoutationID))
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
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendPmRequestForQuotation.SupplierID);
            return View(sendPmRequestForQuotation);
        }

        // GET: SendPmRequestForQuotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendPmRequestForQuotation = await _context.SendPmrequestForQuotations
                .Include(s => s.S)
                .FirstOrDefaultAsync(m => m.SendPmRequestForQoutationID == id);
            if (sendPmRequestForQuotation == null)
            {
                return NotFound();
            }

            return View(sendPmRequestForQuotation);
        }

        // POST: SendPmRequestForQuotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendPmRequestForQuotation = await _context.SendPmrequestForQuotations.FindAsync(id);
            if (sendPmRequestForQuotation != null)
            {
                _context.SendPmrequestForQuotations.Remove(sendPmRequestForQuotation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendPmRequestForQuotationExists(int id)
        {
            return _context.SendPmrequestForQuotations.Any(e => e.SendPmRequestForQoutationID == id);
        }
    }
}
