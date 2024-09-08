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
    public class SendPurchasingRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendPurchasingRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SendPurchasingRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SendPurchasingRequests.Include(s => s.PR).Include(s => s.S);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SendPurchasingRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendPurchasingRequest = await _context.SendPurchasingRequests
                .Include(s => s.PR)
                .Include(s => s.S)
                .FirstOrDefaultAsync(m => m.SendPurchasingRequestID == id);
            if (sendPurchasingRequest == null)
            {
                return NotFound();
            }

            return View(sendPurchasingRequest);
        }

        // GET: SendPurchasingRequests/Create
        public IActionResult Create()
        {
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1");
            return View();
        }

        // POST: SendPurchasingRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendPurchasingRequestID,DateCreated,PurchasingRequestID,SupplierID")] SendPurchasingRequest sendPurchasingRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sendPurchasingRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode", sendPurchasingRequest.PurchasingRequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendPurchasingRequest.SupplierID);
            return View(sendPurchasingRequest);
        }

        // GET: SendPurchasingRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendPurchasingRequest = await _context.SendPurchasingRequests.FindAsync(id);
            if (sendPurchasingRequest == null)
            {
                return NotFound();
            }
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode", sendPurchasingRequest.PurchasingRequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendPurchasingRequest.SupplierID);
            return View(sendPurchasingRequest);
        }

        // POST: SendPurchasingRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendPurchasingRequestID,DateCreated,PurchasingRequestID,SupplierID")] SendPurchasingRequest sendPurchasingRequest)
        {
            if (id != sendPurchasingRequest.SendPurchasingRequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendPurchasingRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendPurchasingRequestExists(sendPurchasingRequest.SendPurchasingRequestID))
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
            ViewData["PurchasingRequestID"] = new SelectList(_context.PurchasingRequest, "PurchasingRequestID", "ItemCode", sendPurchasingRequest.PurchasingRequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendPurchasingRequest.SupplierID);
            return View(sendPurchasingRequest);
        }

        // GET: SendPurchasingRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendPurchasingRequest = await _context.SendPurchasingRequests
                .Include(s => s.PR)
                .Include(s => s.S)
                .FirstOrDefaultAsync(m => m.SendPurchasingRequestID == id);
            if (sendPurchasingRequest == null)
            {
                return NotFound();
            }

            return View(sendPurchasingRequest);
        }

        // POST: SendPurchasingRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendPurchasingRequest = await _context.SendPurchasingRequests.FindAsync(id);
            if (sendPurchasingRequest != null)
            {
                _context.SendPurchasingRequests.Remove(sendPurchasingRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendPurchasingRequestExists(int id)
        {
            return _context.SendPurchasingRequests.Any(e => e.SendPurchasingRequestID == id);
        }
    }
}
