using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class ClassParticipation : IEntity
    {
        public int Id { get; set; }
        public int Listening { get; set; }
        public int Reading { get; set; }
        public int SpokenInteraction { get; set; }
        public int SpokenProduction { get; set; }
        public int Fluency { get; set; }

        public Unit unit { get; set; }
    }
}
