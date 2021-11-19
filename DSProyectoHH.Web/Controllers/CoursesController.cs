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
                .Include(c=>c.CourseType)
                .Include(f=>f.Frequency)
                .Include(s=>s.Schedule)
                .Include(s => s.Schedule)
                .Include(t=>t.Teacher).ThenInclude(t=>t.User)
                .ToListAsync());
        }
        public IActionResult Create()
        {
            var model = new CourseViewModel
            {
                CourseTypes = this.comboHelper.GetComboCourseTypes(),
                Frequencies= this.comboHelper.GetComboFrequencies(),
                Teachers= this.comboHelper.GetComboTeachers(),
                Schedules= this.comboHelper.GetComboSchedules()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    CourseId=model.CourseId,
                    CourseName=model.CourseName,
                                        StartingDate=model.StartingDate,
                    CourseType=await this.dataContext.CourseTypes.FindAsync(model.CourseTypeId),
                    Frequency= await this.dataContext.Frequencies.FindAsync(model.FrequencyId),
                    Schedule = await this.dataContext.Schedules.FindAsync(model.ScheduleId),
                    Teacher= await this.dataContext.Teachers.FindAsync(model.TeacherId)
                };
                this.dataContext.Add(course);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



    }
}
