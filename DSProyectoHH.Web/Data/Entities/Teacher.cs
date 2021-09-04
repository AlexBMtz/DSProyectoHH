using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher
    {   
        private int id_teacher;
        private string name_teacher;
        private string last_name_teacher;
        private int telephone;
        private string email;
        private string rfc;

        public int Id_Teacher { get { return id_teacher; } set { id_teacher = value; } }
        public string Name_Teacher { get { return name_teacher; } set { name_teacher = value; } }
        public string Last_Name_Teacher { get { return last_name_teacher; } set { last_name_teacher = value; } }
        public int Telephone { get { return telephone; } set { telephone = value; } }
        public string Email {  get { return email; } set { email = value; } }
        public string RFC { get { return rfc; } set { rfc = value; } }

    }
}
