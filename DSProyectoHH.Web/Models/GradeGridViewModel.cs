namespace DSProyectoHH.Web.Models
{
    using DSProyectoHH.Web.Data.Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class GradeGridViewModel : GradeGrid
    {
        public int ProjectId { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

        public int UnitId { get; set; }
        public IEnumerable<SelectListItem> UnitsList { get; set; }
    }
}
