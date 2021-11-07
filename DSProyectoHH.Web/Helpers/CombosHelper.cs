using DSProyectoHH.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSProyectoHH.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext dataContext;

        public CombosHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboProjects()
        {
            var list = this.dataContext.Projects.Select(p => new SelectListItem
            {
                Text = Convert.ToString(p.Id),
                Value = $"{p.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Selecciona un proyecto)",
                Value = "0"
            });
            return list;
        }   
    }
}
