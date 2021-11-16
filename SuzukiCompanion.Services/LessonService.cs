using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class LessonService : ILessonService
    {
        public bool CreateLesson(LessonCreate model, string path)
        {
            var entity = new Lesson()
            {
                OwnerId = Guid.Parse(model.UserId),
                LessonName = model.LessonName,
                Contents = model.Contents,
                CreatedUtc = DateTimeOffset.Now,
                ImagePath = path,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Lessons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LessonListItem> GetLessons(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var lessonQuery =
                    ctx
                        .Lessons
                        .Where(e => e.OwnerId == guid)
                        .Select(
                            e =>
                                new LessonListItem
                                {
                                    LessonId = e.LessonId,
                                    LessonName = e.LessonName,
                                    Contents = e.Contents,
                                }
                        );

                return lessonQuery.ToArray();
            }
        }

        public LessonDetail GetLessonById(int id, string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == id && e.OwnerId == guid);
                return

                    new LessonDetail
                    {
                        LessonId = entity.LessonId,
                        LessonName = entity.LessonName,
                        Contents = entity.Contents,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdateLesson(LessonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(model.UserId);
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == model.LessonId && e.OwnerId == guid);


                entity.LessonName = model.LessonName;
                entity.Contents = model.Contents;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLesson(int lessonId, string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == lessonId && e.OwnerId == guid);

                ctx.Lessons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

