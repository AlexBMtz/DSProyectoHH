using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Student
    {
        private int id_student;
        private string name_student;
        private string last_name_student;
        private int telephone;
        private string email;
        private string adress;
        private DateTime admission_date;

        public int Id_Student { get { return id_student; } set { id_student = value; } }
        public string Name_Student { get { return name_student; } set { name_student = value; } }
        public string Last_Name_Student { get { return last_name_student; } set { last_name_student = value; } }
        public int Telephone { get { return telephone; } set { telephone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public DateTime Admission_Date{ get { return admission_date; }set { admission_date = value; } }

    }
}
