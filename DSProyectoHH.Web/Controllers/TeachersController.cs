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
    [Authorize(Roles = "Coordinator,Admin")] 
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
                    var result = await userHelper.AddUserAsync(user, model.TeacherId.ToString());
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("ERROR. No se pudo crear el usuario.");
                    }
                    await userHelper.AddUserToRoleAsync(user, "Teacher");
                }

                var teacher = new Teacher
                {
                    TeacherId = model.TeacherId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.User.FullName,
                        "Teachers"),
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
                var user = await this.dataContext.Users.FindAsync(model.User.Id);
                    user.FirstName = model.User.FirstName;
                    user.LastName = model.User.LastName;
                    user.PhoneNumber = model.User.PhoneNumber;
                    user.Email = model.User.Email;
                    user.UserName = model.User.Email;

                this.dataContext.Update(user);
                await dataContext.SaveChangesAsync();

                var teacher = new Teacher
                {
                    Id = model.Id,
                    TeacherId = model.TeacherId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = (model.ImageUrl != null ?
                        (model.ImageUrl.Contains("_default.png") ?
                        await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Teachers") :
                        await imageHelper.UpdateImageAsync(model.ImageFile, model.ImageUrl)) :
                        await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Teachers")),
                    User = await this.dataContext.Users.FindAsync(model.User.Id)
                };

                this.dataContext.Update(teacher);
                await dataContext.SaveChangesAsync();
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
