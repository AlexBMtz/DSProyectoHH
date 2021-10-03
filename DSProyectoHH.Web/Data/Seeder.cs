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
