using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndustryProduction.Data;
using IndustryProduction.Models;

namespace IndustryProduction.Controllers
{
    public class MachineWorkingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachineWorkingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MachineWorking
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MachineWorkings.Include(m => m.Machine).Include(m => m.Shift);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MachineWorking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineWorking = await _context.MachineWorkings
                .Include(m => m.Machine)
                .Include(m => m.Shift)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineWorking == null)
            {
                return NotFound();
            }

            return View(machineWorking);
        }

        // GET: MachineWorking/Create
        public IActionResult Create()
        {
            ViewData["MachineId"] = new SelectList(_context.MachinesMaster, "Id", "MachineCode");
            ViewData["ShiftId"] = new SelectList(_context.WorkingShifts, "Id", "ShiftName");
            return View();
        }

        // POST: MachineWorking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,ShiftId,Id")] MachineWorking machineWorking)
        {
            //if (ModelState.IsValid)
            //{
            _context.Add(machineWorking);
            await _context.SaveChangesAsync();

            ViewData["MachineId"] = new SelectList(_context.MachinesMaster, "Id", "MachineCode", machineWorking.MachineId);
            ViewData["ShiftId"] = new SelectList(_context.WorkingShifts, "Id", "ShiftName", machineWorking.ShiftId);

            return RedirectToAction(nameof(Index));
            //}

            //return View(machineWorking);
        }

        // GET: MachineWorking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineWorking = await _context.MachineWorkings.FindAsync(id);
            if (machineWorking == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.MachinesMaster, "Id", "MachineCode", machineWorking.MachineId);
            ViewData["ShiftId"] = new SelectList(_context.WorkingShifts, "Id", "ShiftName", machineWorking.ShiftId);
            return View(machineWorking);
        }

        // POST: MachineWorking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineId,ShiftId,Id")] MachineWorking machineWorking)
        {
            if (id != machineWorking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineWorking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineWorkingExists(machineWorking.Id))
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
            ViewData["MachineId"] = new SelectList(_context.MachinesMaster, "Id", "MachineCode", machineWorking.MachineId);
            ViewData["ShiftId"] = new SelectList(_context.WorkingShifts, "Id", "ShiftName", machineWorking.ShiftId);
            return View(machineWorking);
        }

        // GET: MachineWorking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineWorking = await _context.MachineWorkings
                .Include(m => m.Machine)
                .Include(m => m.Shift)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineWorking == null)
            {
                return NotFound();
            }

            return View(machineWorking);
        }

        // POST: MachineWorking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineWorking = await _context.MachineWorkings.FindAsync(id);
            _context.MachineWorkings.Remove(machineWorking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineWorkingExists(int id)
        {
            return _context.MachineWorkings.Any(e => e.Id == id);
        }
    }
}
