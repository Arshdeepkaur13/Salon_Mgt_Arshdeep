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
    public class Appointment_MstController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Appointment_MstController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointment_Mst
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointment_Msts.Include(a => a.Customer_Mst).Include(a => a.Staff_Mst);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointment_Mst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment_Mst = await _context.Appointment_Msts
                .Include(a => a.Customer_Mst)
                .Include(a => a.Staff_Mst)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appointment_Mst == null)
            {
                return NotFound();
            }

            return View(appointment_Mst);
        }

        // GET: Appointment_Mst/Create
        public IActionResult Create()
        {
            ViewData["Customer_MstID"] = new SelectList(_context.Customer_Msts, "ID", "Name");
            ViewData["Staff_MstID"] = new SelectList(_context.Staff_Msts, "ID", "Name");
            return View();
        }

        // POST: Appointment_Mst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Staff_MstID,Customer_MstID,AppointmentDate,Charges")] Appointment_Mst appointment_Mst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment_Mst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_MstID"] = new SelectList(_context.Customer_Msts, "ID", "Name", appointment_Mst.Customer_MstID);
            ViewData["Staff_MstID"] = new SelectList(_context.Staff_Msts, "ID", "Name", appointment_Mst.Staff_MstID);
            return View(appointment_Mst);
        }

        // GET: Appointment_Mst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment_Mst = await _context.Appointment_Msts.FindAsync(id);
            if (appointment_Mst == null)
            {
                return NotFound();
            }
            ViewData["Customer_MstID"] = new SelectList(_context.Customer_Msts, "ID", "Name", appointment_Mst.Customer_MstID);
            ViewData["Staff_MstID"] = new SelectList(_context.Staff_Msts, "ID", "Name", appointment_Mst.Staff_MstID);
            return View(appointment_Mst);
        }

        // POST: Appointment_Mst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Staff_MstID,Customer_MstID,AppointmentDate,Charges")] Appointment_Mst appointment_Mst)
        {
            if (id != appointment_Mst.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment_Mst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Appointment_MstExists(appointment_Mst.ID))
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
            ViewData["Customer_MstID"] = new SelectList(_context.Customer_Msts, "ID", "Name", appointment_Mst.Customer_MstID);
            ViewData["Staff_MstID"] = new SelectList(_context.Staff_Msts, "ID", "Name", appointment_Mst.Staff_MstID);
            return View(appointment_Mst);
        }

        // GET: Appointment_Mst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment_Mst = await _context.Appointment_Msts
                .Include(a => a.Customer_Mst)
                .Include(a => a.Staff_Mst)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appointment_Mst == null)
            {
                return NotFound();
            }

            return View(appointment_Mst);
        }

        // POST: Appointment_Mst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment_Mst = await _context.Appointment_Msts.FindAsync(id);
            _context.Appointment_Msts.Remove(appointment_Mst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Appointment_MstExists(int id)
        {
            return _context.Appointment_Msts.Any(e => e.ID == id);
        }
    }
}
