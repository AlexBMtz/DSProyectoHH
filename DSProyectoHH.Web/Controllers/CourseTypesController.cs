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
    public class CourseTypesController : Controller
    {
        private readonly DataContext _context;

        public CourseTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: CourseTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseTypes.ToListAsync());
        }

        // GET: CourseTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseType = await _context.CourseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseType == null)
            {
                return NotFound();
            }

            return View(courseType);
        }

        // GET: CourseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseType courseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseType);
        }

        // GET: CourseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseType = await _context.CourseTypes.FindAsync(id);
            if (courseType == null)
            {
                return NotFound();
            }
            return View(courseType);
        }

        // POST: CourseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseType courseType)
        {
            if (id != courseType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTypeExists(courseType.Id))
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
            return View(courseType);
        }

        // GET: CourseTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseType = await _context.CourseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseType == null)
            {
                return NotFound();
            }

            return View(courseType);
        }

        // POST: CourseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseType = await _context.CourseTypes.FindAsync(id);
            _context.CourseTypes.Remove(courseType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTypeExists(int id)
        {
            return _context.CourseTypes.Any(e => e.Id == id);
        }
    }
}
