using DSProyectoHH.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<ClassParticipation> ClassParticipations { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<GradeGrid> GradeGrids { get; set; }
        public DbSet<OralQuiz> OralQuizzes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WrittenQuiz> WrittenQuizzes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
