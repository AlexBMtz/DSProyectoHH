namespace DSProyectoHH.Web.Controllers
{
    using DSProyectoHH.Web.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class CourseDetailsController : Controller
    {
        private readonly DataContext dataContext;

        public CourseDetailsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.CourseDetails.ToListAsync());
        }
    }
}
