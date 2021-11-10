using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class TeacherService
    {
        
        private readonly Guid ___userId;

        public TeacherService(Guid __userId)
        {
            ___userId = __userId;
        }
        public bool CreateTeacher(TeacherCreate model)
        {
            var entity =
                new Teacher()
                {
                    OwnerId = ___userId,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Location = model.Location,
                    StartDate = DateTime.Now,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teachers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeacherListItem> GetTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teachers
                        .Where(e => e.OwnerId == ___userId)
                        .Select(
                            e =>
                                new TeacherListItem
                                {
                                    TeacherId = e.TeacherId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email,
                                    PhoneNumber = e.PhoneNumber,
                                    Location = e.Location,
                                    StartDate = DateTime.Now,
                                }
                        );
                return query.ToArray();
            }
        }

        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id && e.OwnerId == ___userId);
                return
                    new TeacherDetail
                    {
                        TeacherId = entity.TeacherId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber,
                        Location = entity.Location,
                        StartDate = DateTime.Now,
                    };
            }
        }
        public bool UpdateTeacher(TeacherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == model.TeacherId && e.OwnerId == ___userId);


                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Location = model.Location;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTeacher(int __userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == __userId && e.OwnerId == ___userId);

                ctx.Teachers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

