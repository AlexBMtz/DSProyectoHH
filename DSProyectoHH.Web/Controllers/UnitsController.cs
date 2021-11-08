namespace DSProyectoHH.Web.Controllers
{
    using DSProyectoHH.Web.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

   [Authorize(Roles = "Teacher,Coordinator")]
    public class UnitsController : Controller
    {
       
        private readonly DataContext dataContext;

        public UnitsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Units.ToListAsync());
        }
    }
}
