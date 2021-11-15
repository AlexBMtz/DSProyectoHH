using Microsoft.AspNetCore.Identity;
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
                var user = await CheckUser("Administrador", "", "2222222222", "admin@gmail.com", "123456");
                await CheckAdmin(user, "Admin");
            }

            if (!this.dataContext.Coordinators.Any())
            {
                var user = await CheckUser("Carlos", "Chávez", "2223242526", "carlos.ch@gmail.com", "123456");
                await CheckCoordinator(user, "Coordinator", 3007136, new DateTime(2020, 10, 3, 6, 0, 0), "CHAC010416R35");

                user = await CheckUser("Paulina", "Pérez", "2728293031", "pau.perez@gmail.com", "334455");
                await CheckCoordinator(user, "Coordinator", 3007137, new DateTime(2020, 10, 3, 6, 0, 0), "PERP051218O12");
            }

            if (!this.dataContext.Teachers.Any())
            {
                var user = await CheckUser("Alejandro", "Barroeta", "2221136875", "abm@gmail.com", "123456");
                await CheckTeacher(user, "Teacher", 3007134, new DateTime(2020, 10, 3, 6, 0, 0), "BAMA010416Q95");

                user = await CheckUser("Carlos", "Vaca", "2225369758", "c.vaca@gmail.com", "789101");
                await CheckTeacher(user, "Teacher", 3007135, new DateTime(2020, 10, 3, 6, 0, 0), "VAMC051218H92");
            }

            if (!this.dataContext.Projects.Any())
            {
                await CheckProject(0, 2, 2, 2, 2);
                await CheckProject(1, 1, 0, 2, 2);
                await CheckProject(2, 0, 2, 0, 1);
            }

            if (!this.dataContext.ClassParticipations.Any())
            {
                await CheckClassParticipation(0, 1, 2, 1, 0);
                await CheckClassParticipation(1, 2, 0, 2, 1);
                await CheckClassParticipation(0, 2, 1, 2, 0);
            }

            if (!this.dataContext.WrittenQuizzes.Any())
            {
                await CheckWrittenQuiz(7, 8, 9, 8, 7, 8);
                await CheckWrittenQuiz(5, 2, 8, 6, 4, 7);
                await CheckWrittenQuiz(3, 6, 9, 8, 5, 2);
            }

            if (!this.dataContext.OralQuizzes.Any())
            {
                await CheckOralQuiz(5, 4, 3, 4, 5);
                await CheckOralQuiz(3, 2, 3, 4, 2);
                await CheckOralQuiz(2, 1, 2, 3, 4);
            }

            if (!this.dataContext.GradeGrids.Any())
            {
                var project = this.dataContext.Projects.FirstOrDefault(c => c.Id == 1);
                await CheckGradeGrid(project, 7.8);

                project = this.dataContext.Projects.FirstOrDefault(c => c.Id == 2);
                await CheckGradeGrid(project, 9.2);

                project = this.dataContext.Projects.FirstOrDefault(c => c.Id == 3);
                await CheckGradeGrid(project, 8.8);
            }

            if (!this.dataContext.Units.Any())
            {
                var classParticipartion = this.dataContext.ClassParticipations.FirstOrDefault(c => c.Id == 1);
                var oralQuiz = this.dataContext.OralQuizzes.FirstOrDefault(f => f.Id == 1);
                var writtenQuiz = this.dataContext.WrittenQuizzes.FirstOrDefault(s => s.Id == 1);
                var gradeGrid = this.dataContext.GradeGrids.FirstOrDefault(g => g.Id == 1);
                await CheckUnit(classParticipartion, oralQuiz, writtenQuiz, gradeGrid);

                classParticipartion = this.dataContext.ClassParticipations.FirstOrDefault(c => c.Id == 2);
                oralQuiz = this.dataContext.OralQuizzes.FirstOrDefault(f => f.Id == 2);
                writtenQuiz = this.dataContext.WrittenQuizzes.FirstOrDefault(s => s.Id == 2);
                gradeGrid = this.dataContext.GradeGrids.FirstOrDefault(g => g.Id == 1);
                await CheckUnit(classParticipartion, oralQuiz, writtenQuiz, gradeGrid);

                classParticipartion = this.dataContext.ClassParticipations.FirstOrDefault(c => c.Id == 3);
                oralQuiz = this.dataContext.OralQuizzes.FirstOrDefault(f => f.Id == 3);
                writtenQuiz = this.dataContext.WrittenQuizzes.FirstOrDefault(s => s.Id == 3);
                gradeGrid = this.dataContext.GradeGrids.FirstOrDefault(g => g.Id == 1);
                await CheckUnit(classParticipartion, oralQuiz, writtenQuiz, gradeGrid);
            }

            if (!this.dataContext.CourseDetails.Any())
            {
                var gradeGrid = this.dataContext.GradeGrids.FirstOrDefault(g => g.Id == 1);
                await CheckCourseDetail(gradeGrid);

                gradeGrid = this.dataContext.GradeGrids.FirstOrDefault(g => g.Id == 2);
                await CheckCourseDetail(gradeGrid);
            }

            if (!this.dataContext.Students.Any())
            {
                var user = await CheckUser("Marco", "Hernandez", "2221136875", "Hernan_Marc@Outlook", "153456");
                var courseDetail = this.dataContext.CourseDetails.FirstOrDefault(c => c.Id == 1);
                await CheckStudent(user, "Student", 1945, DateTime.Today, courseDetail);

                user = await CheckUser("Karla", "Alvarez", "4221136875", "aknm@gmail.com", "123cuatro56");
                courseDetail = this.dataContext.CourseDetails.FirstOrDefault(c => c.Id == 1);
                await CheckStudent(user, "Student", 1948, DateTime.Today, courseDetail);

            }

            if (!this.dataContext.Schedules.Any())
            {
                await CheckSchedule(new DateTime(2020, 10, 3, 6, 0, 0), new DateTime(2020, 10, 3, 8, 0, 0));
                await CheckSchedule(new DateTime(2020, 10, 3, 3, 00, 0), new DateTime(2020, 10, 3, 6, 00, 0));
                await CheckSchedule(new DateTime(2020, 10, 3, 6, 30, 0), new DateTime(2020, 10, 3, 8, 30, 0));
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

                await CheckCourse(203192, "Course 1", new DateTime(2021, 10, 5), frequency, schedule, courseType, courseDetail, teacher);

                frequency = this.dataContext.Frequencies.FirstOrDefault(f => f.Id == 1);
                schedule = this.dataContext.Schedules.FirstOrDefault(s => s.Id == 2);
                courseType = this.dataContext.CourseTypes.FirstOrDefault(c => c.Id == 1);
                courseDetail = this.dataContext.CourseDetails.FirstOrDefault(c => c.Id == 2);
                teacher = this.dataContext.Teachers.FirstOrDefault(t => t.Id == 1);

                await CheckCourse(203193, "Course 1", new DateTime(2021, 10, 5), frequency, schedule, courseType, courseDetail, teacher);
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

        private async Task CheckCourse(int courseId, string courseName, DateTime startingDate, Frequency frequency, Schedule schedule, CourseType courseType, CourseDetail courseDetail, Teacher teacher)
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
                CourseDetail = courseDetail

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

        private async Task CheckStudent(User user, string role, int studentId, DateTime admissionDate, CourseDetail courseDetail)
        {
            this.dataContext.Students.Add(new Student
            {
                User = user,
                StudentId = studentId,
                AdmissionDate = admissionDate,
                CourseDetail = courseDetail
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, role);
        }

        private async Task CheckProject(int research, int productQuality, int collabWork, int creativity, int fluency)
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

        private async Task CheckWrittenQuiz(int sectionA, int sectionB, int sectionC, int sectionD, int sectionE, int sectionF)
        {
            this.dataContext.WrittenQuizzes.Add(new WrittenQuiz
            {
                SectionA = sectionA,
                SectionB = sectionB,
                SectionC = sectionC,
                SectionD = sectionD,
                SectionE = sectionE,
                SectionF = sectionF
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckOralQuiz(int communication, int conversation, int fluency, int grammar, int vocabulary)
        {
            this.dataContext.OralQuizzes.Add(new OralQuiz
            {
                Communication = communication,
                Conversations = conversation,
                Fluency = fluency,
                Grammar = grammar,
                Vocabulary = vocabulary,
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckClassParticipation(int fluency, int listening, int reading, int sInteraction, int sProduction)
        {
            this.dataContext.ClassParticipations.Add(new ClassParticipation
            {
                Fluency = fluency,
                Listening = listening,
                Reading = reading,
                SpokenInteraction = sInteraction,
                SpokenProduction = sProduction
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckGradeGrid(Project finalProject, double finalScore)
        {
            this.dataContext.GradeGrids.Add(new GradeGrid
            {
                FinalProject = finalProject,
                FinalScore = finalScore
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckUnit(ClassParticipation classParticipation, OralQuiz oralQuiz, WrittenQuiz writtenQuiz, GradeGrid gradeGrid)
        {
            this.dataContext.Units.Add(new Unit
            {
                ClassParticipation = classParticipation,
                OralQuiz = oralQuiz,
                WrittenQuiz = writtenQuiz,
                GradeGrid = gradeGrid
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckCourseDetail(GradeGrid gradeGrid)
        {
            this.dataContext.CourseDetails.Add(new CourseDetail
            {
                GradeGrid = gradeGrid
            });

            await dataContext.SaveChangesAsync();
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
