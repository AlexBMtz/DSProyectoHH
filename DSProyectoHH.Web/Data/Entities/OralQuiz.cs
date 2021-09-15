using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class OralQuiz : IEntity
    {
        public int Id { get; set; }
        public int Communication { get; set; }
        public int Grammar { get; set; }
        public int Vocabulary { get; set; }
        public int ConversationS { get; set; }
        public int Fluency { get; set; }

        public Unit unit { get; set; }
    }
}
