namespace DSProyectoHH.Web.Data.Entities
{
    public class GradeGridTemp :IEntity
    {

        public int Id { get; set; }
        public int StudentId {get { return Student.StudentId; } }
        public string StudentName { get { return Student.User.FullName; } }
        public Student Student { get; set; }
    }
}
