namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public StudentGrade StudentGrade { get; set; }
        public double FinalGrade { get; set; }

    }
}
