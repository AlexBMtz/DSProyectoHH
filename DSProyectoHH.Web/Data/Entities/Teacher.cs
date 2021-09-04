using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher
    {
        private int idTeacher;
        private string name;
        private string lastName;
        private int telephone;
        private string email;
        private string rfc;

        public int IdTeacher { get { return idTeacher; } set { idTeacher = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int Telephone { get { return telephone; } set { telephone = value; } }
        public string Email {  get { return email; } set { email = value; } }
        public string RFC { get { return rfc; } set { rfc = value; } }

    }
}
