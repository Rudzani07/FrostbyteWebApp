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
    public class DeliveryNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryNotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeliveryNotes.Include(d => d.S);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeliveryNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryNote = await _context.DeliveryNotes
                .Include(d => d.S)
                .FirstOrDefaultAsync(m => m.DeliveryNoteID == id);
            if (deliveryNote == null)
            {
                return NotFound();
            }

            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Create
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1");
            return View();
        }

        // POST: DeliveryNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryNoteID,DateIssued,SupplierID")] DeliveryNote deliveryNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", deliveryNote.SupplierID);
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryNote = await _context.DeliveryNotes.FindAsync(id);
            if (deliveryNote == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", deliveryNote.SupplierID);
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryNoteID,DateIssued,SupplierID")] DeliveryNote deliveryNote)
        {
            if (id != deliveryNote.DeliveryNoteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryNoteExists(deliveryNote.DeliveryNoteID))
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
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", deliveryNote.SupplierID);
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryNote = await _context.DeliveryNotes
                .Include(d => d.S)
                .FirstOrDefaultAsync(m => m.DeliveryNoteID == id);
            if (deliveryNote == null)
            {
                return NotFound();
            }

            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryNote = await _context.DeliveryNotes.FindAsync(id);
            if (deliveryNote != null)
            {
                _context.DeliveryNotes.Remove(deliveryNote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryNoteExists(int id)
        {
            return _context.DeliveryNotes.Any(e => e.DeliveryNoteID == id);
        }
    }
}
