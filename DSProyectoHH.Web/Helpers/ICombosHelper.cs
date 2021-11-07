using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DSProyectoHH.Web.Helpers
{
    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboProjects();
    }
}
