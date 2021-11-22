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
                .Include(s => s.Schedule)
                .Include(f => f.Frequency)
                .Include(c => c.CourseType)
                .Include(t => t.Teacher)
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
                .Include(s => s.Schedule)
                .Include(f => f.Frequency)
                .Include(c => c.CourseType)
                .Include(t => t.Teacher)
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

                CourseTypeId = (course.CourseType != null ? course.CourseType.Id : 0),
                FrequencyId = (course.Frequency != null ? course.Frequency.Id : 0),
                ScheduleId = (course.Schedule != null ? course.Schedule.Id : 0),
                TeacherId = (course.Teacher != null ? course.Teacher.Id : 0),

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
            if (this.ModelState.IsValid)
            {
                var course = new Course
                {
                    Id = model.Id,
                    CourseId = model.CourseId,
                    CourseName = model.CourseName,
                    CourseType = await this.dataContext.CourseTypes.FindAsync(model.CourseTypeId),
                    Frequency = await this.dataContext.Frequencies.FindAsync(model.FrequencyId),
                    GradeGrid = model.GradeGrid,
                    Schedule = await this.dataContext.Schedules.FindAsync(model.ScheduleId),
                    StartingDate = model.StartingDate,
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
                .Include(s => s.Schedule)
                .Include(f => f.Frequency)
                .Include(c => c.CourseType)
                .Include(c => c.GradeGrid)
                .Include(t => t.Teacher)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(c => c.Id == id);

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
                .Include(cd => cd.GradeGrid)
                .ThenInclude(gg => gg.Student)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            dataContext.Courses.Remove(course);
            var courseDetail = await dataContext.CourseDetails.FindAsync();
            dataContext.CourseDetails.Remove(courseDetail);

            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

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
