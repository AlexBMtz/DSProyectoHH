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

        public IEnumerable<SelectListItem> GetComboCourseTypes()
        {
            var list = this.dataContext.CourseTypes.Select(ct => new SelectListItem
            {
                Text = ct.CourseTypeName,
                Value = $"{ct.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Selecciona un tipo de curso)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboFrequencies()
        {
            var list = this.dataContext.Frequencies.Select(f => new SelectListItem
            {
                Text = f.Name,
                Value = $"{f.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Selecciona una frecuencia)",
                Value = "0"
            });
            return list;
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

        public IEnumerable<SelectListItem> GetComboSchedules()
        {
            var list = this.dataContext.Schedules.Select(s => new SelectListItem
            {
                Text = $"{s.StartingHour.ToShortTimeString()} - {s.EndingHour.ToShortTimeString()}",
                Value = $"{s.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Selecciona un horario)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboStudents()
        {
            var list = this.dataContext.Students.Select(s => new SelectListItem
            {
                Text = s.User.FullName,
                Value = $"{s.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Selecciona un alumno)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboTeachers()
        {
            var list = this.dataContext.Teachers.Select(t => new SelectListItem
            {
                Text = t.User.FullName,
                Value = $"{t.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Selecciona un teacher)",
                Value = "0"
            });
            return list;
        }
    }
}
