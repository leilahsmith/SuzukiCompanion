using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class JourneyService : IJourneyService
    {
        public IEnumerable<LessonListItem> GetLessons(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var journeyQuery =
                   ctx
                       .Lessons
                       .Where(e => e.OwnerId == guid)
                       .Select(
                           e =>
                               new LessonListItem
                               {
                                   LessonId = e.LessonId,
                                   LessonName = e.LessonName,
                                   Contents = e.Contents
                               }
                       );
                return journeyQuery.ToArray();
            }
        }
        public LessonDetail GetLessonById(int lessonId, string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var guid = Guid.Parse(userId);
                var entity =
                    ctx
                        .Lessons
                         .Single(e => e.LessonId == lessonId && e.OwnerId == guid);
                return

                    new LessonDetail
                    {
                        LessonId = entity.LessonId,
                        LessonName = entity.LessonName,
                        Contents = entity.Contents,
                    };
            }
        }
    }
}

