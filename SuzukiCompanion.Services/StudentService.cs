using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class StudentService : IStudentService
    {
        public bool CreateStudent(StudentCreate model, string path)
        {
            var entity = new Student()
            {
                OwnerId = Guid.Parse(model.UserId),
                UserId = model.UserId,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Location = model.Location,
                StartDate = DateTime.Now,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StudentListItem> GetStudents(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var studentQuery =
                    ctx
                        .Students
                        .Where(e => e.OwnerId == guid)
                        .Select(
                            e =>
                                new StudentListItem
                                {
                                    StudentId = e.StudentId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email,
                                    Age = e.Age,
                                    PhoneNumber = e.PhoneNumber,
                                    Location = e.Location,
                                    StartDate = DateTime.Now,
                                }
                        );
                return studentQuery.ToArray();
            }
        }

        public StudentDetail GetStudentById(int studentId, string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == studentId && e.OwnerId == guid);
                return
                    new StudentDetail
                    {
                        StudentId = entity.StudentId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Age = entity.Age,
                        PhoneNumber = entity.PhoneNumber,
                        Location = entity.Location,
                        StartDate = DateTime.Now,
                    };
            }
        }
        public bool UpdateStudent(StudentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(model.UserId);
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == model.StudentId && e.OwnerId == guid);


                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Age = model.Age;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Location = model.Location;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteStudent(int studentId, string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == studentId && e.OwnerId == guid);

                ctx.Students.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
