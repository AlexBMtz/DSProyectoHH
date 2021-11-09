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
                    var result = await userHelper.AddUserAsync(user, "123456");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("ERROR. No se pudo crear el usuario.");
                    }
                }

                var coordinator = new Coordinator
                {
                    CoordinatorId = model.CoordinatorId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.User.FullName,
                        "Coordinators") : string.Empty),
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

                var coordinator = new Coordinator
                {
                    Id = model.Id,
                    CoordinatorId = model.CoordinatorId,
                    HiringDate = model.HiringDate,
                    RFC = model.RFC,
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.User.FullName,
                        "Coordinators") : model.ImageUrl),
                    User = await this.dataContext.Users.FindAsync(model.User.Id)
                };
                try
                {
                    dataContext.Update(coordinator);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(coordinator.Id))
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
