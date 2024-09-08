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
    public class SupplierRequestForQoutationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierRequestForQoutationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupplierRequestForQoutations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SupplierRequestForQuotations.Include(s => s.D);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SupplierRequestForQoutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierRequestForQoutation = await _context.SupplierRequestForQuotations
                .Include(s => s.D)
                .FirstOrDefaultAsync(m => m.SupplierRequestForQuotationID == id);
            if (supplierRequestForQoutation == null)
            {
                return NotFound();
            }

            return View(supplierRequestForQoutation);
        }

        // GET: SupplierRequestForQoutations/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            return View();
        }

        // POST: SupplierRequestForQoutations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierRequestForQuotationID,DateIssued,SupplierID,ItemCode,ItemName,Specification,DepartmentID,ItemModel,ItemSerialNumber,Unit,Quantity,EstimatedPrice,QoutedPrice,PaymentSpecifications,DeliverySpecification,TermsCondition")] SupplierRequestForQoutation supplierRequestForQoutation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierRequestForQoutation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", supplierRequestForQoutation.DepartmentID);
            return View(supplierRequestForQoutation);
        }

        // GET: SupplierRequestForQoutations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierRequestForQoutation = await _context.SupplierRequestForQuotations.FindAsync(id);
            if (supplierRequestForQoutation == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", supplierRequestForQoutation.DepartmentID);
            return View(supplierRequestForQoutation);
        }

        // POST: SupplierRequestForQoutations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierRequestForQuotationID,DateIssued,SupplierID,ItemCode,ItemName,Specification,DepartmentID,ItemModel,ItemSerialNumber,Unit,Quantity,EstimatedPrice,QoutedPrice,PaymentSpecifications,DeliverySpecification,TermsCondition")] SupplierRequestForQoutation supplierRequestForQoutation)
        {
            if (id != supplierRequestForQoutation.SupplierRequestForQuotationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierRequestForQoutation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierRequestForQoutationExists(supplierRequestForQoutation.SupplierRequestForQuotationID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", supplierRequestForQoutation.DepartmentID);
            return View(supplierRequestForQoutation);
        }

        // GET: SupplierRequestForQoutations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierRequestForQoutation = await _context.SupplierRequestForQuotations
                .Include(s => s.D)
                .FirstOrDefaultAsync(m => m.SupplierRequestForQuotationID == id);
            if (supplierRequestForQoutation == null)
            {
                return NotFound();
            }

            return View(supplierRequestForQoutation);
        }

        // POST: SupplierRequestForQoutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierRequestForQoutation = await _context.SupplierRequestForQuotations.FindAsync(id);
            if (supplierRequestForQoutation != null)
            {
                _context.SupplierRequestForQuotations.Remove(supplierRequestForQoutation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierRequestForQoutationExists(int id)
        {
            return _context.SupplierRequestForQuotations.Any(e => e.SupplierRequestForQuotationID == id);
        }
    }
}
