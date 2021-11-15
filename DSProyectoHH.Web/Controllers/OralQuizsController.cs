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
    [Authorize(Roles = "Teacher,Coordinator,Admin")]
    
    public class OralQuizsController : Controller
    {
        private readonly DataContext _context;

        public OralQuizsController(DataContext context)
        {
            _context = context;
        }

        // GET: OralQuizs
        public async Task<IActionResult> Index()
        {
            return View(await _context.OralQuizzes.ToListAsync());
        }

        // GET: OralQuizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oralQuiz = await _context.OralQuizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oralQuiz == null)
            {
                return NotFound();
            }

            return View(oralQuiz);
        }

        // GET: OralQuizs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OralQuizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OralQuiz oralQuiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oralQuiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oralQuiz);
        }

        // GET: OralQuizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oralQuiz = await _context.OralQuizzes.FindAsync(id);
            if (oralQuiz == null)
            {
                return NotFound();
            }
            return View(oralQuiz);
        }

        // POST: OralQuizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OralQuiz oralQuiz)
        {
            if (id != oralQuiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oralQuiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OralQuizExists(oralQuiz.Id))
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
            return View(oralQuiz);
        }

        // GET: OralQuizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oralQuiz = await _context.OralQuizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oralQuiz == null)
            {
                return NotFound();
            }

            return View(oralQuiz);
        }

        // POST: OralQuizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oralQuiz = await _context.OralQuizzes.FindAsync(id);
            _context.OralQuizzes.Remove(oralQuiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OralQuizExists(int id)
        {
            return _context.OralQuizzes.Any(e => e.Id == id);
        }
    }
}
