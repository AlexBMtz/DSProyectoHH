using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Unit:IEntity
    {
        public int Id { get; set; }
        public WrittenQuiz WrittenQuiz { get; set; }
        public OralQuiz OralQuiz { get; set; }
        public ClassParticipation ClassParticipation { get; set; }
    }
}
