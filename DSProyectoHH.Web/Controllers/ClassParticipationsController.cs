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
    //[Authorize(Roles ="Teacher,Coordinator")]
    public class ClassParticipationsController : Controller
    {
        private readonly DataContext _context;

        public ClassParticipationsController(DataContext context)
        {
            _context = context;
        }
        
        // GET: ClassParticipations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassParticipations.ToListAsync());
        }

        // GET: ClassParticipations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classParticipation = await _context.ClassParticipations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classParticipation == null)
            {
                return NotFound();
            }

            return View(classParticipation);
        }

        // GET: ClassParticipations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassParticipations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassParticipation classParticipation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classParticipation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classParticipation);
        }

        // GET: ClassParticipations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classParticipation = await _context.ClassParticipations.FindAsync(id);
            if (classParticipation == null)
            {
                return NotFound();
            }
            return View(classParticipation);
        }

        // POST: ClassParticipations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassParticipation classParticipation)
        {
            if (id != classParticipation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classParticipation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassParticipationExists(classParticipation.Id))
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
            return View(classParticipation);
        }

        // GET: ClassParticipations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classParticipation = await _context.ClassParticipations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classParticipation == null)
            {
                return NotFound();
            }

            return View(classParticipation);
        }

        // POST: ClassParticipations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classParticipation = await _context.ClassParticipations.FindAsync(id);
            _context.ClassParticipations.Remove(classParticipation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassParticipationExists(int id)
        {
            return _context.ClassParticipations.Any(e => e.Id == id);
        }
    }
}
