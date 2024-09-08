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
    public class SendDeliveryNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendDeliveryNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SendDeliveryNotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SendDeliveryNotes.Include(s => s.PM);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SendDeliveryNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendDeliveryNote = await _context.SendDeliveryNotes
                .Include(s => s.PM)
                .FirstOrDefaultAsync(m => m.SendDeliveryID == id);
            if (sendDeliveryNote == null)
            {
                return NotFound();
            }

            return View(sendDeliveryNote);
        }

        // GET: SendDeliveryNotes/Create
        public IActionResult Create()
        {
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1");
            return View();
        }

        // POST: SendDeliveryNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendDeliveryID,OrdrID,PurchasingManagerID")] SendDeliveryNote sendDeliveryNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sendDeliveryNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", sendDeliveryNote.PurchasingManagerID);
            return View(sendDeliveryNote);
        }

        // GET: SendDeliveryNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendDeliveryNote = await _context.SendDeliveryNotes.FindAsync(id);
            if (sendDeliveryNote == null)
            {
                return NotFound();
            }
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", sendDeliveryNote.PurchasingManagerID);
            return View(sendDeliveryNote);
        }

        // POST: SendDeliveryNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendDeliveryID,OrdrID,PurchasingManagerID")] SendDeliveryNote sendDeliveryNote)
        {
            if (id != sendDeliveryNote.SendDeliveryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendDeliveryNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendDeliveryNoteExists(sendDeliveryNote.SendDeliveryID))
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
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", sendDeliveryNote.PurchasingManagerID);
            return View(sendDeliveryNote);
        }

        // GET: SendDeliveryNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendDeliveryNote = await _context.SendDeliveryNotes
                .Include(s => s.PM)
                .FirstOrDefaultAsync(m => m.SendDeliveryID == id);
            if (sendDeliveryNote == null)
            {
                return NotFound();
            }

            return View(sendDeliveryNote);
        }

        // POST: SendDeliveryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendDeliveryNote = await _context.SendDeliveryNotes.FindAsync(id);
            if (sendDeliveryNote != null)
            {
                _context.SendDeliveryNotes.Remove(sendDeliveryNote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendDeliveryNoteExists(int id)
        {
            return _context.SendDeliveryNotes.Any(e => e.SendDeliveryID == id);
        }
    }
}
