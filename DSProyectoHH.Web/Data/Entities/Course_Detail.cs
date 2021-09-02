using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course_Detail
    {
        private Unit unit1;
        private Unit unit2;
        private Unit unit3;
        private Proyect finalproyect;
        private double finalscore;

        public Unit Unit_1 { get { return unit1; } set { unit1 = value; } }
        public Unit Unit_2 { get { return unit2; } set { unit2 = value; } }
        public Unit Unit_3 { get { return unit3; } set { unit3 = value; } }
        public Proyect Final_Proyect { get { return finalproyect; } set { finalproyect = value; } }
        public double Final_Score { get { return finalscore; } set { finalscore = value; } }

        public void Calculate_Final_Score()
        {
            //finalscore = (unit1 * 0.3) + (unit2 * 0.3) + (unit3 * 0.3) + (finalproyect * 0.1);
        }
    }
}
