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
    public class PurchasingManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasingManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchasingManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchasingManagers.ToListAsync());
        }

        // GET: PurchasingManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasingManager = await _context.PurchasingManagers
                .FirstOrDefaultAsync(m => m.PurchasingManagerID == id);
            if (purchasingManager == null)
            {
                return NotFound();
            }

            return View(purchasingManager);
        }

        // GET: PurchasingManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchasingManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchasingManagerID,FirstName,LastName,Username,Department,Phone,Address1,Address2,City,Province,ZipCode")] PurchasingManager purchasingManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchasingManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchasingManager);
        }

        // GET: PurchasingManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasingManager = await _context.PurchasingManagers.FindAsync(id);
            if (purchasingManager == null)
            {
                return NotFound();
            }
            return View(purchasingManager);
        }

        // POST: PurchasingManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchasingManagerID,FirstName,LastName,Username,Department,Phone,Address1,Address2,City,Province,ZipCode")] PurchasingManager purchasingManager)
        {
            if (id != purchasingManager.PurchasingManagerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchasingManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchasingManagerExists(purchasingManager.PurchasingManagerID))
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
            return View(purchasingManager);
        }

        // GET: PurchasingManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasingManager = await _context.PurchasingManagers
                .FirstOrDefaultAsync(m => m.PurchasingManagerID == id);
            if (purchasingManager == null)
            {
                return NotFound();
            }

            return View(purchasingManager);
        }

        // POST: PurchasingManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchasingManager = await _context.PurchasingManagers.FindAsync(id);
            if (purchasingManager != null)
            {
                _context.PurchasingManagers.Remove(purchasingManager);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchasingManagerExists(int id)
        {
            return _context.PurchasingManagers.Any(e => e.PurchasingManagerID == id);
        }
    }
}
