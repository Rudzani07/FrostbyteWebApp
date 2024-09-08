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
    public class PurchasingRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasingRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchasingRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchasingRequest.Include(p => p.D).Include(p => p.Inv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchasingRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasingRequest = await _context.PurchasingRequest
                .Include(p => p.D)
                .Include(p => p.Inv)
                .FirstOrDefaultAsync(m => m.PurchasingRequestID == id);
            if (purchasingRequest == null)
            {
                return NotFound();
            }

            return View(purchasingRequest);
        }

        // GET: PurchasingRequests/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1");
            return View();
        }

        // POST: PurchasingRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchasingRequestID,DateIssued,InventoryLiaisonID,ItemCode,ItemName,Specification,DepartmentID,ItemModel,ItemSerialNumber,Unit,Quantity,EstimatedPrice")] PurchasingRequest purchasingRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchasingRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", purchasingRequest.DepartmentID);
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1", purchasingRequest.InventoryLiaisonID);
            return View(purchasingRequest);
        }

        // GET: PurchasingRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasingRequest = await _context.PurchasingRequest.FindAsync(id);
            if (purchasingRequest == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", purchasingRequest.DepartmentID);
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1", purchasingRequest.InventoryLiaisonID);
            return View(purchasingRequest);
        }

        // POST: PurchasingRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchasingRequestID,DateIssued,InventoryLiaisonID,ItemCode,ItemName,Specification,DepartmentID,ItemModel,ItemSerialNumber,Unit,Quantity,EstimatedPrice")] PurchasingRequest purchasingRequest)
        {
            if (id != purchasingRequest.PurchasingRequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchasingRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchasingRequestExists(purchasingRequest.PurchasingRequestID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", purchasingRequest.DepartmentID);
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1", purchasingRequest.InventoryLiaisonID);
            return View(purchasingRequest);
        }

        // GET: PurchasingRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasingRequest = await _context.PurchasingRequest
                .Include(p => p.D)
                .Include(p => p.Inv)
                .FirstOrDefaultAsync(m => m.PurchasingRequestID == id);
            if (purchasingRequest == null)
            {
                return NotFound();
            }

            return View(purchasingRequest);
        }

        // POST: PurchasingRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchasingRequest = await _context.PurchasingRequest.FindAsync(id);
            if (purchasingRequest != null)
            {
                _context.PurchasingRequest.Remove(purchasingRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchasingRequestExists(int id)
        {
            return _context.PurchasingRequest.Any(e => e.PurchasingRequestID == id);
        }
    }
}
