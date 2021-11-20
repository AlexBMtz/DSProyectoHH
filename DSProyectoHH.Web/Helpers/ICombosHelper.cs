using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DSProyectoHH.Web.Helpers
{
    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboProjects();
        public IEnumerable<SelectListItem> GetComboCourseTypes();
        public IEnumerable<SelectListItem> GetComboFrequencies();
        public IEnumerable<SelectListItem> GetComboTeachers();
        public IEnumerable<SelectListItem> GetComboSchedules();
        public IEnumerable<SelectListItem> GetComboStudents();

    }
}
