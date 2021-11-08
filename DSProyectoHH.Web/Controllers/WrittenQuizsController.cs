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
    [Authorize(Roles = "Teacher,Coordinator")]

    public class WrittenQuizsController : Controller
    {
        private readonly DataContext _context;

        public WrittenQuizsController(DataContext context)
        {
            _context = context;
        }

        // GET: WrittenQuizs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WrittenQuizzes.ToListAsync());
        }

        // GET: WrittenQuizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writtenQuiz = await _context.WrittenQuizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writtenQuiz == null)
            {
                return NotFound();
            }

            return View(writtenQuiz);
        }

        // GET: WrittenQuizs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WrittenQuizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WrittenQuiz writtenQuiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(writtenQuiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(writtenQuiz);
        }

        // GET: WrittenQuizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writtenQuiz = await _context.WrittenQuizzes.FindAsync(id);
            if (writtenQuiz == null)
            {
                return NotFound();
            }
            return View(writtenQuiz);
        }

        // POST: WrittenQuizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WrittenQuiz writtenQuiz)
        {
            if (id != writtenQuiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(writtenQuiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WrittenQuizExists(writtenQuiz.Id))
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
            return View(writtenQuiz);
        }

        // GET: WrittenQuizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writtenQuiz = await _context.WrittenQuizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writtenQuiz == null)
            {
                return NotFound();
            }

            return View(writtenQuiz);
        }

        // POST: WrittenQuizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var writtenQuiz = await _context.WrittenQuizzes.FindAsync(id);
            _context.WrittenQuizzes.Remove(writtenQuiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WrittenQuizExists(int id)
        {
            return _context.WrittenQuizzes.Any(e => e.Id == id);
        }
    }
}
