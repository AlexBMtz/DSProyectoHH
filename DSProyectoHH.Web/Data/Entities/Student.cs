using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Student : IEntity
    {
      /*
        private int id;
        private string name;
        private string lastName;
        private int phoneNumber;
        private string email;
        private string adress;
        private DateTime admissionDate;
      */

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime AdmissionDate { get; set; }

    }
}
