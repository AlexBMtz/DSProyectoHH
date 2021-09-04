using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class WrittenQuiz : IEntity
    {
        public int Id { get; set; }
        public int SectionA { get; set; }
        public int SectionB { get; set; }
        public int SectionC { get; set; }
        public int SectionD { get; set; }
        public int SectionE { get; set; }
        public int SectionF { get; set; }

    }
}
