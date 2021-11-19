namespace DSProyectoHH.Web.Controllers
{
    using DSProyectoHH.Web.Data;
    using DSProyectoHH.Web.Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = "Coordinator,Admin")]
    public class CourseDetailsController : Controller
    {

        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;
        private readonly ICombosHelper combosHelper;

        public CourseDetailsController(DataContext dataContext,IUserHelper userHelper,ICombosHelper combosHelper )
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
            this.combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(dataContext.CourseDetails.Include(s=>s.GradeGrids).ThenInclude(s=>s.Student));
        }
    }
}
