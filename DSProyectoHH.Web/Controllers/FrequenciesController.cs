using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSProyectoHH.Web.Data;
using DSProyectoHH.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace DSProyectoHH.Web.Controllers
{
    [Authorize(Roles = "Coordinator")]
    public class FrequenciesController : Controller
    {
        private readonly DataContext _context;

        public FrequenciesController(DataContext context)
        {
            _context = context;
        }

        // GET: Frequencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Frequencies.ToListAsync());
        }

        // GET: Frequencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequency = await _context.Frequencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frequency == null)
            {
                return NotFound();
            }

            return View(frequency);
        }

        // GET: Frequencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frequencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frequency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);
        }

        // GET: Frequencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequency = await _context.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return NotFound();
            }
            return View(frequency);
        }

        // POST: Frequencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Frequency frequency)
        {
            if (id != frequency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frequency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrequencyExists(frequency.Id))
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
            return View(frequency);
        }

        // GET: Frequencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequency = await _context.Frequencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frequency == null)
            {
                return NotFound();
            }

            return View(frequency);
        }

        // POST: Frequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frequency = await _context.Frequencies.FindAsync(id);
            _context.Frequencies.Remove(frequency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrequencyExists(int id)
        {
            return _context.Frequencies.Any(e => e.Id == id);
        }
    }
}
