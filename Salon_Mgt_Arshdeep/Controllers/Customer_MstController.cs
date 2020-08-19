using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon_Mgt_Arshdeep.Data;
using Salon_Mgt_Arshdeep.Models;

namespace Salon_Mgt_Arshdeep.Controllers
{
    public class Customer_MstController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Customer_MstController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer_Mst
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer_Msts.ToListAsync());
        }

        // GET: Customer_Mst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Mst = await _context.Customer_Msts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer_Mst == null)
            {
                return NotFound();
            }

            return View(customer_Mst);
        }

        // GET: Customer_Mst/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer_Mst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,Email,PhoneNo,Address")] Customer_Mst customer_Mst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer_Mst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer_Mst);
        }

        // GET: Customer_Mst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Mst = await _context.Customer_Msts.FindAsync(id);
            if (customer_Mst == null)
            {
                return NotFound();
            }
            return View(customer_Mst);
        }

        // POST: Customer_Mst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,Email,PhoneNo,Address")] Customer_Mst customer_Mst)
        {
            if (id != customer_Mst.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer_Mst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer_MstExists(customer_Mst.ID))
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
            return View(customer_Mst);
        }

        // GET: Customer_Mst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Mst = await _context.Customer_Msts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer_Mst == null)
            {
                return NotFound();
            }

            return View(customer_Mst);
        }

        // POST: Customer_Mst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer_Mst = await _context.Customer_Msts.FindAsync(id);
            _context.Customer_Msts.Remove(customer_Mst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customer_MstExists(int id)
        {
            return _context.Customer_Msts.Any(e => e.ID == id);
        }
    }
}
