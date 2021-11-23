﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            await userHelper.CheckRoleAsync("Coordinator");
            await userHelper.CheckRoleAsync("Student");
            await userHelper.CheckRoleAsync("Teacher");

            if (!this.dataContext.Admins.Any())
            {
                var user = await CheckUser("Administrador", "", "2222222222", "admin@gmail.com", "1234567");
                await CheckAdmin(user, "Admin");
            }

            if (!this.dataContext.Coordinators.Any())
            {
                var user = await CheckUser("Carlos", "Chávez", "2223242526", "carlos.ch@gmail.com", "1234567");
                await CheckCoordinator(user, "Coordinator", 3007136, new DateTime(2020, 10, 3, 6, 0, 0), "CHAC010416R35");

                user = await CheckUser("Paulina", "Pérez", "2728293031", "pau.perez@gmail.com", "3344557");
                await CheckCoordinator(user, "Coordinator", 3007137, new DateTime(2020, 10, 3, 6, 0, 0), "PERP051218O12");
            }

            if (!this.dataContext.Teachers.Any())
            {
                var user = await CheckUser("Alejandro", "Barroeta", "2221136875", "abm@gmail.com", "1234567");
                await CheckTeacher(user, "Teacher", 3007134, new DateTime(2020, 10, 3, 6, 0, 0), "BAMA010416Q95");

                user = await CheckUser("Carlos", "Vaca", "2225369758", "c.vaca@gmail.com", "7891017");
                await CheckTeacher(user, "Teacher", 3007135, new DateTime(2020, 10, 3, 6, 0, 0), "VAMC051218H92");
            }

            if (!this.dataContext.Students.Any())
            {
                var user = await CheckUser("Marco", "Hernandez", "2221136875", "Hernan_Marc@outlook.com", "1534567");
                await CheckStudent(user, "Student", 1945, DateTime.Today);

                user = await CheckUser("Karla", "Alvarez", "4221136875", "aknm@gmail.com", "123karl");
                await CheckStudent(user, "Student", 1948, DateTime.Today);

            }

            if (!this.dataContext.Schedules.Any())
            {
                await CheckSchedule(new DateTime(2020, 10, 3, 18, 0, 0), new DateTime(2020, 10, 3, 20, 0, 0));
                await CheckSchedule(new DateTime(2020, 10, 3, 15, 00, 0), new DateTime(2020, 10, 3, 18, 00, 0));
                await CheckSchedule(new DateTime(2020, 10, 3, 19, 00, 0), new DateTime(2020, 10, 3, 20, 30, 0));
                await CheckSchedule(new DateTime(2020, 10, 3, 9, 00, 0), new DateTime(2020, 10, 3, 11, 00, 0));
            }

            if (!this.dataContext.Frequencies.Any())
            {
                await CheckFrequency("Free Friday");
                await CheckFrequency("Saturday");
                await CheckFrequency("Sunday");
            }

            if (!this.dataContext.CourseTypes.Any())
            {
                await CheckCourseType("Preteens");
                await CheckCourseType("Adults");
                await CheckCourseType("Teens");
            }

            if (!this.dataContext.Courses.Any())
            {
                var frequency = this.dataContext.Frequencies.FirstOrDefault(f => f.Id == 1);
                var schedule = this.dataContext.Schedules.FirstOrDefault(s => s.Id == 1);
                var courseType = this.dataContext.CourseTypes.FirstOrDefault(c => c.Id == 1);
                var courseDetail = this.dataContext.CourseDetails.FirstOrDefault(c => c.Id == 1);
                var teacher = this.dataContext.Teachers.FirstOrDefault(t => t.Id == 1);

                //await CheckCourse(203192, "Course 1", new DateTime(2021, 10, 5), frequency, schedule, courseType, courseDetail, teacher);

                frequency = this.dataContext.Frequencies.FirstOrDefault(f => f.Id == 1);
                schedule = this.dataContext.Schedules.FirstOrDefault(s => s.Id == 2);
                courseType = this.dataContext.CourseTypes.FirstOrDefault(c => c.Id == 1);
                courseDetail = this.dataContext.CourseDetails.FirstOrDefault(c => c.Id == 2);
                teacher = this.dataContext.Teachers.FirstOrDefault(t => t.Id == 1);

                //await CheckCourse(203193, "Course 2", new DateTime(2021, 11, 5), frequency, schedule, courseType, courseDetail, teacher);
            }
        }

        private async Task CheckAdmin(User user, string role)
        {
            this.dataContext.Admins.Add(new Admin
            {
                User = user
            });

            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, role);
        }

        private async Task CheckCoordinator(User user, string role, int coordinatorId, DateTime hiringDate, string rfc)
        {
            this.dataContext.Coordinators.Add(new Coordinator
            {
                CoordinatorId = coordinatorId,
                HiringDate = hiringDate,
                RFC = rfc,
                User = user
            });

            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, role);
        }

        private async Task CheckCourse(int courseId, string courseName, DateTime startingDate, Frequency frequency, Schedule schedule, CourseType courseType, IOrderedEnumerable<CourseDetail> courseDetail, Teacher teacher)
        {
            this.dataContext.Courses.Add(new Course
            {
                CourseId = courseId,
                CourseName = courseName,
                StartingDate = startingDate,
                Frequency = frequency,
                Schedule = schedule,
                CourseType = courseType,
                Teacher = teacher,
                GradeGrid = courseDetail

            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckCourseType(string courseTypeName)
        {
            this.dataContext.CourseTypes.Add(new CourseType
            {
                CourseTypeName = courseTypeName
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckFrequency(string name)
        {
            this.dataContext.Frequencies.Add(new Frequency
            {
                Name = name
            }
            );
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckSchedule(DateTime startingHour, DateTime endingHour)
        {
            this.dataContext.Schedules.Add(new Schedule
            {
                StartingHour = startingHour,
                EndingHour = endingHour

            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckTeacher(User user, string role, int teacherId, DateTime hiringDate, string rfc)
        {
            this.dataContext.Teachers.Add(new Teacher
            {
                TeacherId = teacherId,
                User = user,
                HiringDate = hiringDate,
                RFC = rfc
            }
            );

            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, role);
        }

        private async Task CheckStudent(User user, string role, int studentId, DateTime admissionDate)
        {
            this.dataContext.Students.Add(new Student
            {
                User = user,
                StudentId = studentId,
                AdmissionDate = admissionDate,
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, role);
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
