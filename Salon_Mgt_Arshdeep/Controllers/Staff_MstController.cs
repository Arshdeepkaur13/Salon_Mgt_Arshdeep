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
    public class Staff_MstController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Staff_MstController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff_Mst
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staff_Msts.ToListAsync());
        }

        // GET: Staff_Mst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_Mst = await _context.Staff_Msts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff_Mst == null)
            {
                return NotFound();
            }

            return View(staff_Mst);
        }

        // GET: Staff_Mst/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff_Mst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,Email,PhoneNo")] Staff_Mst staff_Mst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff_Mst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff_Mst);
        }

        // GET: Staff_Mst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_Mst = await _context.Staff_Msts.FindAsync(id);
            if (staff_Mst == null)
            {
                return NotFound();
            }
            return View(staff_Mst);
        }

        // POST: Staff_Mst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,Email,PhoneNo")] Staff_Mst staff_Mst)
        {
            if (id != staff_Mst.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff_Mst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Staff_MstExists(staff_Mst.ID))
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
            return View(staff_Mst);
        }

        // GET: Staff_Mst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_Mst = await _context.Staff_Msts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff_Mst == null)
            {
                return NotFound();
            }

            return View(staff_Mst);
        }

        // POST: Staff_Mst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff_Mst = await _context.Staff_Msts.FindAsync(id);
            _context.Staff_Msts.Remove(staff_Mst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Staff_MstExists(int id)
        {
            return _context.Staff_Msts.Any(e => e.ID == id);
        }
    }
}
