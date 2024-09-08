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
    public class UserTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserTypes.Include(u => u.Ad).Include(u => u.Client).Include(u => u.Inv).Include(u => u.Pum).Include(u => u.Sup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserTypes
                .Include(u => u.Ad)
                .Include(u => u.Client)
                .Include(u => u.Inv)
                .Include(u => u.Pum)
                .Include(u => u.Sup)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (userType == null)
            {
                return NotFound();
            }

            return View(userType);
        }

        // GET: UserTypes/Create
        public IActionResult Create()
        {
            ViewData["AdminID"] = new SelectList(_context.Admins, "AdminID", "Address1");
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Address1");
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1");
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1");
            return View();
        }

        // POST: UserTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,DateTime,SupplierID,InventoryLiaisonID,ClientID,AdminID,PurchasingManagerID")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminID"] = new SelectList(_context.Admins, "AdminID", "Address1", userType.AdminID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Address1", userType.ClientID);
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1", userType.InventoryLiaisonID);
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", userType.PurchasingManagerID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", userType.SupplierID);
            return View(userType);
        }

        // GET: UserTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }
            ViewData["AdminID"] = new SelectList(_context.Admins, "AdminID", "Address1", userType.AdminID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Address1", userType.ClientID);
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1", userType.InventoryLiaisonID);
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", userType.PurchasingManagerID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", userType.SupplierID);
            return View(userType);
        }

        // POST: UserTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,DateTime,SupplierID,InventoryLiaisonID,ClientID,AdminID,PurchasingManagerID")] UserType userType)
        {
            if (id != userType.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTypeExists(userType.UserID))
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
            ViewData["AdminID"] = new SelectList(_context.Admins, "AdminID", "Address1", userType.AdminID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Address1", userType.ClientID);
            ViewData["InventoryLiaisonID"] = new SelectList(_context.InventoryLiaisons, "InventoryLiaisonID", "Address1", userType.InventoryLiaisonID);
            ViewData["PurchasingManagerID"] = new SelectList(_context.PurchasingManagers, "PurchasingManagerID", "Address1", userType.PurchasingManagerID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", userType.SupplierID);
            return View(userType);
        }

        // GET: UserTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userType = await _context.UserTypes
                .Include(u => u.Ad)
                .Include(u => u.Client)
                .Include(u => u.Inv)
                .Include(u => u.Pum)
                .Include(u => u.Sup)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (userType == null)
            {
                return NotFound();
            }

            return View(userType);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userType = await _context.UserTypes.FindAsync(id);
            if (userType != null)
            {
                _context.UserTypes.Remove(userType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTypeExists(int id)
        {
            return _context.UserTypes.Any(e => e.UserID == id);
        }
    }
}
