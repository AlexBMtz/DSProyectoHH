using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Project
    {
        private int id_project;
        private int productQuality;
        private int collabWork;
        private int creativity;
        private int fluency;

        public int Id_Project { get { return id_project; } set { id_project = value; } }
        public int ProductQuality { get { return productQuality; } set { productQuality = value; } }
        public int CollabWork { get { return collabWork; } set { collabWork = value; } }
        public int Creativity {  get { return creativity;  } set { creativity = value; } }
        public int Fluency { get { return fluency;  } set { fluency = value; } }

    }
}
