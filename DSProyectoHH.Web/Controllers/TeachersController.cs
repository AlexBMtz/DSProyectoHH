using DSProyectoHH.Web.Data;
using DSProyectoHH.Web.Data.Entities;
using DSProyectoHH.Web.Helpers;
using DSProyectoHH.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Controllers
{
    [Authorize(Roles = "Coordinator")] 
    public class TeachersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IImageHelper imageHelper;
        private readonly IUserHelper userHelper;

        public TeachersController(DataContext dataContext,
            IImageHelper imageHelper, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.imageHelper = imageHelper;
            this.userHelper = userHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Teachers
                .Include(u => u.User)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await this.dataContext.Teachers
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByIdAsync(model.User.Id);
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = model.User.FirstName,
                        LastName = model.User.LastName,
                        PhoneNumber = model.User.PhoneNumber,
                        Email = model.User.Email,
                        UserName = model.User.Email
                    };
                    var result = await userHelper.AddUserAsync(user, "123456");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("ERROR. No se pudo crear el usuario.");
                    }
                }

                var teacher = new Teacher
                {
                    TeacherId = model.TeacherId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.User.FullName,
                        "Teachers") : string.Empty),
                    User = await this.dataContext.Users.FindAsync(user.Id)
                };
                dataContext.Add(teacher);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await this.dataContext.Teachers
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            
            if (teacher == null)
            {
                return NotFound();
            }

            var model = new TeacherViewModel
            {
                Id = teacher.Id,
                TeacherId = teacher.TeacherId,
                HiringDate = teacher.HiringDate,
                ImageUrl = teacher.ImageUrl,
                RFC = teacher.RFC,
                User = teacher.User
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: No actualiza datos propios del usuario, pero si de profesor
                var user = new User
                {
                    Id = model.User.Id,
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    PhoneNumber = model.User.PhoneNumber,
                    Email = model.User.Email,
                    UserName = model.User.Email
                };
                try
                {
                    dataContext.Update(user);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                var teacher = new Teacher
                {
                    Id = model.Id,
                    TeacherId = model.TeacherId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.User.FullName,
                        "Teachers") : model.ImageUrl),
                    User = await this.dataContext.Users.FindAsync(model.User.Id)
                };
                try
                {
                    dataContext.Update(teacher);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await this.dataContext.Teachers
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await this.dataContext.Teachers
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            dataContext.Teachers.Remove(teacher);
            var user = await dataContext.Users.FindAsync(teacher.User.Id);
            dataContext.Users.Remove(user);

            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return dataContext.Teachers.Any(e => e.Id == id);
        }

        private bool UserExists(string id)
        {
            return dataContext.Users.Any(e => e.Id == id);
        }
    }
}
