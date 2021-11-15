using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Admin:IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
