﻿namespace DSProyectoHH.Web.Data.Entities
{
    public class GradeGrid:IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
    }
}
