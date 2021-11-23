﻿using DSProyectoHH.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSProyectoHH.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<CourseDetailTemp> CourseDetailTemps { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
