using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class LessonService
    {
        private readonly Guid _userId;
        public LessonService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLesson(LessonCreate model)
        {
            var entity =
                new Lesson()
                {
                    OwnerId = _userId,
                    LessonName = model.LessonName,
                    Contents = model.Contents,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Lessons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LessonListItem> GetLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Lessons
                        .Select(
                            e =>
                                new LessonListItem
                                {
                                    LessonId = e.LessonId,
                                    LessonName = e.LessonName,
                                    Contents = e.Contents,
                                    Pdf = e.Pdf,
                                    Video = e.Video,
                                    Photo = e.Photo,
                                }
                        );

                return query.ToArray();
            }
        }
        public LessonDetail GetLessonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == id && e.OwnerId == _userId);
                return
                    new LessonDetail
                    {
                        LessonId = entity.LessonId,
                        LessonName = entity.LessonName,
                        Contents = entity.Contents,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        Pdf = entity.Pdf,
                        Video = entity.Video,
                        Photo = entity.Photo,
                    };
            }
        }
        public bool UpdateLesson(LessonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == model.LessonId && e.OwnerId == _userId);

                
                entity.LessonName = model.LessonName;
                entity.Contents = model.Contents;
                entity.Pdf = model.Pdf;
                entity.Video = model.Video;
                entity.Photo = model.Photo;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLesson(int lessonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == lessonId && e.OwnerId == _userId);

                ctx.Lessons.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

