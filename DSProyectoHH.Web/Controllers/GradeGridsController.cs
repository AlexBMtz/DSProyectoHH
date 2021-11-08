namespace DSProyectoHH.Web.Controllers
{
    using DSProyectoHH.Web.Data;
    using DSProyectoHH.Web.Data.Entities;
    using DSProyectoHH.Web.Helpers;
    using DSProyectoHH.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    [Authorize(Roles = "Teacher,Coordinator")]
    public class GradeGridsController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public GradeGridsController(DataContext dataContext, ICombosHelper combosHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
        }
        [Authorize(Roles ="Student,Teacher,Coordinator")]
        public async Task<IActionResult> Index()
        {
            return View(await dataContext.GradeGrids.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new GradeGridViewModel
            {
                Projects = this.combosHelper.GetComboProjects()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GradeGridViewModel model)
        {
            if (ModelState.IsValid)
            {
                var gradeGrid = new GradeGrid
                {
                    FinalProject = await this.dataContext.Projects.FindAsync(model.ProjectId),
                    FinalScore = model.FinalScore,
                    //Units = await this.dataContext.Units.FindAsync(model.UnitId)
                    //Este lo deje por que es una relacion a muchos
                };
                this.dataContext.Add(model);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }



        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
