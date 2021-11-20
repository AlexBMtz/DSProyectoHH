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
    public class CourseDetailsController : Controller
    {

        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public CourseDetailsController(DataContext dataContext, ICombosHelper combosHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(dataContext.CourseDetails.Include(s => s.GradeGrids).ThenInclude(s => s.Student).ThenInclude(u => u.User));
        }

        public IActionResult Create()
        {
            var model = this.dataContext.GradeGridTemps.Include(od => od.Student).ThenInclude(u => u.User);
            return View(model);
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

                var gradeGridTemp = await this.dataContext.GradeGridTemps.Where(s => s.Student == student).FirstOrDefaultAsync();

                if (gradeGridTemp == null)
                {
                    gradeGridTemp = new GradeGridTemp
                    {
                        Student = student
                    };

                    this.dataContext.GradeGridTemps.Add(gradeGridTemp);
                }

                await this.dataContext.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            return View(model);
        }

        public async Task<IActionResult> SaveList()
        {
            var gradeGridTemps = await this.dataContext.GradeGridTemps.Include(odt => odt.Student).ToListAsync();

            if (gradeGridTemps == null || gradeGridTemps.Count == 0)
                return NotFound();

            var details = gradeGridTemps.Select(ggt => new GradeGrid
            {
                Student = ggt.Student

            }).ToList();

            var order = new CourseDetail
            {
                GradeGrids = details
            };

            this.dataContext.CourseDetails.Add(order);
            this.dataContext.GradeGridTemps.RemoveRange(gradeGridTemps);

            await this.dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
