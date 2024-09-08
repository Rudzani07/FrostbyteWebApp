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
    public class SendOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SendOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SendOrders.Include(s => s.O).Include(s => s.S);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SendOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendOrder = await _context.SendOrders
                .Include(s => s.O)
                .Include(s => s.S)
                .FirstOrDefaultAsync(m => m.SendOrderID == id);
            if (sendOrder == null)
            {
                return NotFound();
            }

            return View(sendOrder);
        }

        // GET: SendOrders/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "AccountHolder");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1");
            return View();
        }

        // POST: SendOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendOrderID,CreatedDate,OrderID,SupplierID")] SendOrder sendOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sendOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "AccountHolder", sendOrder.OrderID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendOrder.SupplierID);
            return View(sendOrder);
        }

        // GET: SendOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendOrder = await _context.SendOrders.FindAsync(id);
            if (sendOrder == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "AccountHolder", sendOrder.OrderID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendOrder.SupplierID);
            return View(sendOrder);
        }

        // POST: SendOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendOrderID,CreatedDate,OrderID,SupplierID")] SendOrder sendOrder)
        {
            if (id != sendOrder.SendOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendOrderExists(sendOrder.SendOrderID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "AccountHolder", sendOrder.OrderID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "Address1", sendOrder.SupplierID);
            return View(sendOrder);
        }

        // GET: SendOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendOrder = await _context.SendOrders
                .Include(s => s.O)
                .Include(s => s.S)
                .FirstOrDefaultAsync(m => m.SendOrderID == id);
            if (sendOrder == null)
            {
                return NotFound();
            }

            return View(sendOrder);
        }

        // POST: SendOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendOrder = await _context.SendOrders.FindAsync(id);
            if (sendOrder != null)
            {
                _context.SendOrders.Remove(sendOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendOrderExists(int id)
        {
            return _context.SendOrders.Any(e => e.SendOrderID == id);
        }
    }
}
