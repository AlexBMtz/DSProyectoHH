using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher : IEntity
    {
       /*
        private int id;
        private string name;
        private string lastName;
        private int telephone;
        private string email;
        private string rfc;
       */

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }

    }
}
