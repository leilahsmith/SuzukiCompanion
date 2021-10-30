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
        public bool CreateLesson(LessonCreate model)
        {
            var entity =
                new Lesson()
                {
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
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

