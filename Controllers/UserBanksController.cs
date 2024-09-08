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
    public class UserBanksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserBanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserBanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banks1.ToListAsync());
        }

        // GET: UserBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBank = await _context.Banks1
                .FirstOrDefaultAsync(m => m.UserBankID == id);
            if (userBank == null)
            {
                return NotFound();
            }

            return View(userBank);
        }

        // GET: UserBanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserBankID,BankName,BranchCodeName")] UserBank userBank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userBank);
        }

        // GET: UserBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBank = await _context.Banks1.FindAsync(id);
            if (userBank == null)
            {
                return NotFound();
            }
            return View(userBank);
        }

        // POST: UserBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserBankID,BankName,BranchCodeName")] UserBank userBank)
        {
            if (id != userBank.UserBankID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBankExists(userBank.UserBankID))
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
            return View(userBank);
        }

        // GET: UserBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBank = await _context.Banks1
                .FirstOrDefaultAsync(m => m.UserBankID == id);
            if (userBank == null)
            {
                return NotFound();
            }

            return View(userBank);
        }

        // POST: UserBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBank = await _context.Banks1.FindAsync(id);
            if (userBank != null)
            {
                _context.Banks1.Remove(userBank);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBankExists(int id)
        {
            return _context.Banks1.Any(e => e.UserBankID == id);
        }
    }
}
