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
    [Authorize(Roles = "Admin")]
    public class CoordinatorsController : Controller
    {
        private readonly IUserHelper userHelper;
        private readonly DataContext dataContext;
        private readonly IImageHelper imageHelper;

        public CoordinatorsController(IUserHelper userHelper, DataContext dataContext, IImageHelper imageHelper)
        {
            this.userHelper = userHelper;
            this.dataContext = dataContext;
            this.imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Coordinators
                .Include(u => u.User)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinator = await this.dataContext.Coordinators
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (coordinator == null)
            {
                return NotFound();
            }

            return View(coordinator);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoordinatorViewModel model)
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
                    var result = await userHelper.AddUserAsync(user, model.CoordinatorId.ToString());
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("ERROR. No se pudo crear el usuario.");
                    }
                    await userHelper.AddUserToRoleAsync(user, "Coordinator");
                }

                var coordinator = new Coordinator
                {
                    CoordinatorId = model.CoordinatorId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.User.FullName,
                        "Coordinators"),
                    User = await this.dataContext.Users.FindAsync(user.Id)
                };
                dataContext.Add(coordinator);
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

            var coordinator = await this.dataContext.Coordinators
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (coordinator == null)
            {
                return NotFound();
            }

            var model = new CoordinatorViewModel
            {
                Id = coordinator.Id,
                CoordinatorId = coordinator.CoordinatorId,
                HiringDate = coordinator.HiringDate,
                ImageUrl = coordinator.ImageUrl,
                RFC = coordinator.RFC,
                User = coordinator.User
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoordinatorViewModel model)
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

                var coordinator = new Coordinator
                {
                    Id = model.Id,
                    CoordinatorId = model.CoordinatorId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = (model.ImageUrl != null ?
                        (model.ImageUrl.Contains("_default.png") ?
                        await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Coordinators") :
                        await imageHelper.UpdateImageAsync(model.ImageFile, model.ImageUrl)) :
                        await imageHelper.UploadImageAsync(model.ImageFile, model.User.FullName, "Coordinators")),
                    User = await this.dataContext.Users.FindAsync(model.User.Id)
                };

                this.dataContext.Update(coordinator);
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

            var coordinator = await this.dataContext.Coordinators
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (coordinator == null)
            {
                return NotFound();
            }

            return View(coordinator);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordinator = await this.dataContext.Coordinators
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            dataContext.Coordinators.Remove(coordinator);
            var user = await dataContext.Users.FindAsync(coordinator.User.Id);
            dataContext.Users.Remove(user);

            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return dataContext.Coordinators.Any(e => e.Id == id);
        }

        private bool UserExists(string id)
        {
            return dataContext.Users.Any(e => e.Id == id);
        }
    }
}
