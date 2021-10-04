using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await userHelper.CheckRoleAsync("Admin");
            await userHelper.CheckRoleAsync("Student");
            await userHelper.CheckRoleAsync("Teacher");

            if (!this.dataContext.Courses.Any())
            {
                await CheckCourse(1984,"Course 1", DateTime.Today);
                await CheckCourse(2025, "Course 2", DateTime.Today);
                await CheckCourse(2137, "Course 3", DateTime.Today);
            }
            if(!this.dataContext.Students.Any())
            {
                await CheckStudent(1945, DateTime.Today);
                await CheckStudent(1345, DateTime.Today);
                await CheckStudent(0945, DateTime.Today);
            }
            if(!this.dataContext.Projects.Any())
            {
               await CheckProject(9, 10, 10, 10, 10);
               await CheckProject(10, 6, 6, 10, 10);
               await CheckProject(10, 10, 10, 7, 10);
            }


        }

        private async Task CheckCourse(int courseId, string courseName, DateTime startingDate)
        {
            this.dataContext.Courses.Add(new Course
            {
                CourseId = courseId,
                CourseName=courseName,
                StartingDate=startingDate
            }) ;
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckStudent(int studentId, DateTime admissionDate)
        {
            this.dataContext.Students.Add(new Student
            {
                StudentId = studentId,
                AdmissionDate = admissionDate
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckProject(int research,int productQuality, int collabWork, int creativity, int fluency)
        {
            this.dataContext.Projects.Add(new Project
            {
               Research = research,
               ProductQuality = productQuality,
               CollabWork = collabWork,
               Creativity = creativity,
               Fluency = fluency
            });
            await this.dataContext.SaveChangesAsync();
        }


        private async Task<User> CheckUser(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            var user = await userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    UserName = email
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Error no se pudo crear el usuario");
                }
            }
            return user;
        }
    }
}
