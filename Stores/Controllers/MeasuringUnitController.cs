using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stores.App_Data;

namespace Stores.Models
{
    public class MeasuringUnitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasuringUnitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeasuringUnit
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeasuringUnit.ToListAsync());
        }

        // GET: MeasuringUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measuringUnit = await _context.MeasuringUnit
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (measuringUnit == null)
            {
                return NotFound();
            }

            return View(measuringUnit);
        }

        // GET: MeasuringUnit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeasuringUnit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeasuringUnitId,Unit")] MeasuringUnit measuringUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measuringUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measuringUnit);
        }

        // GET: MeasuringUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measuringUnit = await _context.MeasuringUnit.FindAsync(id);
            if (measuringUnit == null)
            {
                return NotFound();
            }
            return View(measuringUnit);
        }

        // POST: MeasuringUnit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("MeasuringUnitId,Unit")] MeasuringUnit measuringUnit)
        {
            if (id != measuringUnit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measuringUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasuringUnitExists(measuringUnit.UnitId))
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
            return View(measuringUnit);
        }

        // GET: MeasuringUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measuringUnit = await _context.MeasuringUnit
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (measuringUnit == null)
            {
                return NotFound();
            }

            return View(measuringUnit);
        }

        // POST: MeasuringUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var measuringUnit = await _context.MeasuringUnit.FindAsync(id);
            _context.MeasuringUnit.Remove(measuringUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasuringUnitExists(int? id)
        {
            return _context.MeasuringUnit.Any(e => e.UnitId == id);
        }
    }
}
