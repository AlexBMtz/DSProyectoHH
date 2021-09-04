using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Student
    {
        private int id;
        private string name;
        private string lastName;
        private int phoneNumber;
        private string email;
        private string adress;
        private DateTime admissionDate;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public DateTime AdmissionDate{ get { return admissionDate; }set { admissionDate = value; } }

    }
}
