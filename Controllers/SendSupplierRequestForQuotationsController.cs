using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrostbyteWebApp.Data.Services;
using FrostbyteWebApp.Models;

namespace FrostbyteWebApp.Controllers
{
    public class SendSupplierRequestForQuotationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendSupplierRequestForQuotationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SendSupplierRequestForQuotations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SendSupplierRequestForQuotations.Include(s => s.PM).Include(s => s.SRFQ);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SendSupplierRequestForQuotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendSupplierRequestForQuotation = await _context.SendSupplierRequestForQuotations
                .Include(s => s.PM)
                .Include(s => s.SRFQ)
                .FirstOrDefaultAsync(m => m.SendSupplierPmRequestForQoutationID == id);
            if (sendSupplierRequestForQuotation == null)
            {
                return NotFound();
            }

            return View(sendSupplierRequestForQuotation);
        }

        // GET: SendSupplierRequestForQuotations/Create
        public IActionResult Create()
        {
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1");
            ViewData["SupplierRequestForQoutationID"] = new SelectList(_context.SupplierRequestForQuotations, "SupplierRequestForQuotationID", "ItemCode");
            return View();
        }

        // POST: SendSupplierRequestForQuotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendSupplierPmRequestForQoutationID,DateCreated,ValidUntil,SupplierRequestForQoutationID,PurchasingManagerID")] SendSupplierRequestForQuotation sendSupplierRequestForQuotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sendSupplierRequestForQuotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", sendSupplierRequestForQuotation.PurchasingManagerID);
            ViewData["SupplierRequestForQoutationID"] = new SelectList(_context.SupplierRequestForQuotations, "SupplierRequestForQuotationID", "ItemCode", sendSupplierRequestForQuotation.SupplierRequestForQoutationID);
            return View(sendSupplierRequestForQuotation);
        }

        // GET: SendSupplierRequestForQuotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendSupplierRequestForQuotation = await _context.SendSupplierRequestForQuotations.FindAsync(id);
            if (sendSupplierRequestForQuotation == null)
            {
                return NotFound();
            }
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", sendSupplierRequestForQuotation.PurchasingManagerID);
            ViewData["SupplierRequestForQoutationID"] = new SelectList(_context.SupplierRequestForQuotations, "SupplierRequestForQuotationID", "ItemCode", sendSupplierRequestForQuotation.SupplierRequestForQoutationID);
            return View(sendSupplierRequestForQuotation);
        }

        // POST: SendSupplierRequestForQuotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendSupplierPmRequestForQoutationID,DateCreated,ValidUntil,SupplierRequestForQoutationID,PurchasingManagerID")] SendSupplierRequestForQuotation sendSupplierRequestForQuotation)
        {
            if (id != sendSupplierRequestForQuotation.SendSupplierPmRequestForQoutationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendSupplierRequestForQuotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendSupplierRequestForQuotationExists(sendSupplierRequestForQuotation.SendSupplierPmRequestForQoutationID))
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
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", sendSupplierRequestForQuotation.PurchasingManagerID);
            ViewData["SupplierRequestForQoutationID"] = new SelectList(_context.SupplierRequestForQuotations, "SupplierRequestForQuotationID", "ItemCode", sendSupplierRequestForQuotation.SupplierRequestForQoutationID);
            return View(sendSupplierRequestForQuotation);
        }

        // GET: SendSupplierRequestForQuotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendSupplierRequestForQuotation = await _context.SendSupplierRequestForQuotations
                .Include(s => s.PM)
                .Include(s => s.SRFQ)
                .FirstOrDefaultAsync(m => m.SendSupplierPmRequestForQoutationID == id);
            if (sendSupplierRequestForQuotation == null)
            {
                return NotFound();
            }

            return View(sendSupplierRequestForQuotation);
        }

        // POST: SendSupplierRequestForQuotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendSupplierRequestForQuotation = await _context.SendSupplierRequestForQuotations.FindAsync(id);
            if (sendSupplierRequestForQuotation != null)
            {
                _context.SendSupplierRequestForQuotations.Remove(sendSupplierRequestForQuotation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendSupplierRequestForQuotationExists(int id)
        {
            return _context.SendSupplierRequestForQuotations.Any(e => e.SendSupplierPmRequestForQoutationID == id);
        }
    }
}
