namespace DSProyectoHH.Web.Controllers
{
    using DSProyectoHH.Web.Data;
    using DSProyectoHH.Web.Data.Entities;
    using DSProyectoHH.Web.Helpers;
    using DSProyectoHH.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = "Coordinator,Admin")]
    public class CoursesController : Controller
    {

        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public CoursesController(DataContext dataContext, ICombosHelper combosHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(this.dataContext.Courses
                .Include(d => d.GradeGrid)
                .ThenInclude(s => s.Student)
                .ThenInclude(u => u.User));
        }

        public IActionResult Create()
        {
            var model = this.dataContext.CourseDetailTemps
                .Include(sd => sd.Student)
                .ThenInclude(ud => ud.User);
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this.dataContext.Courses
                .Include(cd => cd.GradeGrid)
                .ThenInclude(gg => gg.Student)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this.dataContext.Courses
                .Include(c=>c.GradeGrid)
                .ThenInclude(gg=>gg.Student)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var model = new CourseViewModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseType = course.CourseType,
                Frequency = course.Frequency,
                GradeGrid = course.GradeGrid,
                Schedule = course.Schedule,
                StartingDate = course.StartingDate,
                Teacher = course.Teacher,

                CourseTypes = this.combosHelper.GetComboCourseTypes(),
                Frequencies = this.combosHelper.GetComboFrequencies(),
                Schedules = this.combosHelper.GetComboSchedules(),
                Teachers = this.combosHelper.GetComboTeachers()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var courseType = await this.dataContext.CourseTypes.FindAsync(model.CourseTypeId);
                if (courseType == null)
                    return NotFound();

                var frequency = await this.dataContext.Frequencies.FindAsync(model.FrequencyId);
                if (frequency == null)
                    return NotFound();

                var schedule = await this.dataContext.Schedules.FindAsync(model.ScheduleId);
                if (schedule == null)
                    return NotFound();

                var teacher = await this.dataContext.Teachers.FindAsync(model.TeacherId);
                if (teacher == null)
                    return NotFound();

                var course = new Course
                {
                    CourseId = model.CourseId,
                    CourseName = model.CourseName,
                    CourseType = courseType,
                    Frequency = frequency,
                    GradeGrid = model.GradeGrid,
                    Schedule = schedule,
                    StartingDate = model.StartingDate,
                    Teacher = teacher
                };

                this.dataContext.Update(course);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //public async Task<IActionResult> Delete(int? id)
        //{

        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //}

        public IActionResult AddStudent()
        {
            var model = new AddStudentViewModel
            {
                Students = this.combosHelper.GetComboStudents()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var student = await this.dataContext.Students.FindAsync(model.StudentId);
                if (student == null)
                {
                    return NotFound();
                }

                var courseDetailTemp = await this.dataContext.CourseDetailTemps
                    .Where(s => s.Student == student)
                    .FirstOrDefaultAsync();
                if (courseDetailTemp == null)
                {
                    courseDetailTemp = new CourseDetailTemp
                    {
                        Student = student
                    };

                    this.dataContext.CourseDetailTemps.Add(courseDetailTemp);
                }

                await this.dataContext.SaveChangesAsync();
                return this.RedirectToAction("Create");
            }

            return this.View(model);
        }

        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var courseDetailTemp = await this.dataContext.CourseDetailTemps.FindAsync(id);
            if (courseDetailTemp == null)
            {
                return NotFound();
            }
            this.dataContext.CourseDetailTemps.Remove(courseDetailTemp);
            await this.dataContext.SaveChangesAsync();
            return this.RedirectToAction("Create");
        }

        //public async Task<IActionResult> EditStudent(int? id)
        //{

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditStudent(ViewModel model)
        //{

        //}

        public async Task<IActionResult> SaveList()
        {
            var courseDetailTemps = await this.dataContext.CourseDetailTemps
                .Include(odt => odt.Student)
                .ThenInclude(udt=>udt.User)
                .ToListAsync();

            if (courseDetailTemps == null || courseDetailTemps.Count == 0)
                return NotFound();

            var details = courseDetailTemps.Select(d => new CourseDetail
            {
                Student = d.Student
            }).ToList();

            var course = new Course
            {
                CourseId = -1,
                CourseName = "Nuevo_Curso",
                GradeGrid = details
            };

            this.dataContext.Courses.Add(course);
            this.dataContext.CourseDetailTemps.RemoveRange(courseDetailTemps);

            await this.dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
