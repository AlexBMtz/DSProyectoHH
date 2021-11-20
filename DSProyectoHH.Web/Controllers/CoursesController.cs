using DSProyectoHH.Web.Data;
using DSProyectoHH.Web.Data.Entities;
using DSProyectoHH.Web.Helpers;
using DSProyectoHH.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper comboHelper;

        public CoursesController(DataContext dataContext, ICombosHelper comboHelper)
        {
            this.dataContext = dataContext;
            this.comboHelper = comboHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Courses
                .Include(c => c.CourseType)
                .Include(f => f.Frequency)
                .Include(s => s.Schedule)
                .Include(s => s.Schedule)
                .Include(t => t.Teacher).ThenInclude(t => t.User)
                .ToListAsync());
        }
        public IActionResult Create()
        {
            var model = new CourseViewModel
            {
                CourseTypes = this.comboHelper.GetComboCourseTypes(),
                Frequencies = this.comboHelper.GetComboFrequencies(),
                Teachers = this.comboHelper.GetComboTeachers(),
                Schedules = this.comboHelper.GetComboSchedules()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    CourseId = model.CourseId,
                    CourseName = model.CourseName,
                    StartingDate = model.StartingDate,
                    CourseType = await this.dataContext.CourseTypes.FindAsync(model.CourseTypeId),
                    Frequency = await this.dataContext.Frequencies.FindAsync(model.FrequencyId),
                    Schedule = await this.dataContext.Schedules.FindAsync(model.ScheduleId),
                    Teacher = await this.dataContext.Teachers.FindAsync(model.TeacherId)
                };
                this.dataContext.Add(course);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this.dataContext.Courses
                .Include(c => c.CourseType)
                .Include(f => f.Frequency)
                .Include(s => s.Schedule)
                .Include(s => s.Schedule)
                .Include(t => t.Teacher).ThenInclude(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var model = new CourseViewModel
            {
                Id = course.Id,
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartingDate = course.StartingDate,
                Frequency = course.Frequency,
                FrequencyId = course.Frequency.Id,
                Schedule = course.Schedule,
                ScheduleId = course.Schedule.Id,
                CourseType = course.CourseType,
                CourseTypeId = course.CourseType.Id,
                Teacher = course.Teacher,
                TeacherId = course.Teacher.Id,

                CourseTypes = this.comboHelper.GetComboCourseTypes(),
                Frequencies = this.comboHelper.GetComboFrequencies(),
                Schedules = this.comboHelper.GetComboSchedules(),
                Teachers = this.comboHelper.GetComboTeachers()

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Id = model.Id,
                    CourseId = model.CourseId,
                    CourseName = model.CourseName,
                    StartingDate = model.StartingDate,

                    Frequency = await this.dataContext.Frequencies.FindAsync(model.FrequencyId),

                    Schedule = await this.dataContext.Schedules.FindAsync(model.ScheduleId),

                    CourseType = await this.dataContext.CourseTypes.FindAsync(model.CourseTypeId),

                    Teacher = await this.dataContext.Teachers.FindAsync(model.TeacherId)




                };
                this.dataContext.Update(course);
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

            var course = await this.dataContext.Courses
               .Include(c => c.CourseType)
                .Include(f => f.Frequency)
                .Include(s => s.Schedule)
                .Include(s => s.Schedule)
                .Include(t => t.Teacher).ThenInclude(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await this.dataContext.Courses
                .Include(c => c.CourseType)
                .Include(f => f.Frequency)
                .Include(s => s.Schedule)
                .Include(s => s.Schedule)
                .Include(t => t.Teacher).ThenInclude(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            dataContext.Courses.Remove(course);



            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
