using DSProyectoHH.Web.Data;
using DSProyectoHH.Web.Data.Entities;
using DSProyectoHH.Web.Helpers;
using DSProyectoHH.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Controllers
{
    [Authorize(Roles = "Coordinator,Admin")]
    public class StudentsController : Controller
    {
        private static int idNumber = 3006000;
        private readonly DataContext dataContext;
        private readonly IImageHelper imageHelper;
        private readonly IUserHelper userHelper;

        public StudentsController(DataContext dataContext,
            IImageHelper imageHelper, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.imageHelper = imageHelper;
            this.userHelper = userHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Students
                .Include(u => u.User)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await dataContext.Students
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                idNumber += 1;

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
                    var result = await userHelper.AddUserAsync(user, idNumber.ToString());
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("ERROR. No se pudo crear el usuario.");
                    }
                    await userHelper.AddUserToRoleAsync(user, "Student");
                }

                var student = new Student
                {
                    StudentId = idNumber,
                    AdmissionDate = model.AdmissionDate,
                    ImageUrl = await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Students"),
                    User = await this.dataContext.Users.FindAsync(user.Id)
                };
                dataContext.Add(student);
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

            var student = await dataContext.Students
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var model = new StudentViewModel
            {
                Id = student.Id,
                StudentId = student.StudentId,
                AdmissionDate = student.AdmissionDate,
                ImageUrl = student.ImageUrl,
                User = student.User
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel model)
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

                var student = new Student
                {
                    Id = model.Id,
                    StudentId = model.StudentId,
                    AdmissionDate = model.AdmissionDate,
                    ImageUrl = (model.ImageUrl != null ?
                        (model.ImageUrl.Contains("_default.png") ?
                        await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Students") :
                        await imageHelper.UpdateImageAsync(model.ImageFile, model.ImageUrl)) :
                        await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Students")),
                    User = await this.dataContext.Users.FindAsync(user.Id)
                };

                this.dataContext.Update(student);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await dataContext.Students
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await dataContext.Students
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            var courseDetail = await dataContext.CourseDetails
                .FirstOrDefaultAsync(cd => cd.Student.Id == student.Id);

            if(courseDetail!=null)
                dataContext.CourseDetails.Remove(courseDetail);

            dataContext.Students.Remove(student);

            var user = await dataContext.Users
                .FindAsync(student.User.Id);
            dataContext.Users.Remove(user);

            try
            {
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "El alumno está asignado a un curso. No se puede eliminar");
                return View(student);
            }
        }
    }
}
