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
    public class InventoryLiaisonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryLiaisonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InventoryLiaisons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InventoryLiaisons.Include(i => i.DepID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InventoryLiaisons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryLiaison = await _context.InventoryLiaisons
                .Include(i => i.DepID)
                .FirstOrDefaultAsync(m => m.InventoryLiaisonID == id);
            if (inventoryLiaison == null)
            {
                return NotFound();
            }

            return View(inventoryLiaison);
        }

        // GET: InventoryLiaisons/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");
            return View();
        }

        // POST: InventoryLiaisons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryLiaisonID,FirstName,LastName,Username,DepartmentID,Phone,Address1,Address2,City,Province,ZipCode")] InventoryLiaison inventoryLiaison)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryLiaison);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", inventoryLiaison.DepartmentID);
            return View(inventoryLiaison);
        }

        // GET: InventoryLiaisons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryLiaison = await _context.InventoryLiaisons.FindAsync(id);
            if (inventoryLiaison == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", inventoryLiaison.DepartmentID);
            return View(inventoryLiaison);
        }

        // POST: InventoryLiaisons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryLiaisonID,FirstName,LastName,Username,DepartmentID,Phone,Address1,Address2,City,Province,ZipCode")] InventoryLiaison inventoryLiaison)
        {
            if (id != inventoryLiaison.InventoryLiaisonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryLiaison);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryLiaisonExists(inventoryLiaison.InventoryLiaisonID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID", inventoryLiaison.DepartmentID);
            return View(inventoryLiaison);
        }

        // GET: InventoryLiaisons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryLiaison = await _context.InventoryLiaisons
                .Include(i => i.DepID)
                .FirstOrDefaultAsync(m => m.InventoryLiaisonID == id);
            if (inventoryLiaison == null)
            {
                return NotFound();
            }

            return View(inventoryLiaison);
        }

        // POST: InventoryLiaisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryLiaison = await _context.InventoryLiaisons.FindAsync(id);
            if (inventoryLiaison != null)
            {
                _context.InventoryLiaisons.Remove(inventoryLiaison);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryLiaisonExists(int id)
        {
            return _context.InventoryLiaisons.Any(e => e.InventoryLiaisonID == id);
        }
    }
}
