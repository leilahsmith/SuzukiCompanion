using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class StudentService
    {
        private readonly Guid _userId;

        public StudentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    OwnerId = _userId,
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
        public IEnumerable<StudentListItem> GetStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Students
                        .Where(e => e.OwnerId == _userId)
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
                return query.ToArray();
            }
        }

        public StudentDetail GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == id && e.OwnerId == _userId);
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
                var entity =
                    ctx
                        .Students
                        .Single(e => e.StudentId == model.StudentId && e.OwnerId == _userId);

                
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
    }
}
