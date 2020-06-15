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
    public class WorkingShiftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkingShiftController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkingShift
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkingShifts.ToListAsync());
        }

        // GET: WorkingShift/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingShift = await _context.WorkingShifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingShift == null)
            {
                return NotFound();
            }

            return View(workingShift);
        }

        // GET: WorkingShift/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkingShift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftName,StartTime,EndTime,WorkingHr,WorkingMin,Id")] WorkingShift workingShift)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(workingShift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(workingShift);
        }

        // GET: WorkingShift/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingShift = await _context.WorkingShifts.FindAsync(id);
            if (workingShift == null)
            {
                return NotFound();
            }
            return View(workingShift);
        }

        // POST: WorkingShift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftName,StartTime,EndTime,WorkingHr,WorkingMin,Id")] WorkingShift workingShift)
        {
            if (id != workingShift.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingShift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingShiftExists(workingShift.Id))
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
            return View(workingShift);
        }

        // GET: WorkingShift/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingShift = await _context.WorkingShifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingShift == null)
            {
                return NotFound();
            }

            return View(workingShift);
        }

        // POST: WorkingShift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workingShift = await _context.WorkingShifts.FindAsync(id);
            _context.WorkingShifts.Remove(workingShift);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingShiftExists(int id)
        {
            return _context.WorkingShifts.Any(e => e.Id == id);
        }
    }
}
