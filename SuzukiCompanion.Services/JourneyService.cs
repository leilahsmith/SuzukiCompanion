using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Services
{
    public class JourneyService
    {
        private readonly Guid _userId;
        public JourneyService(Guid userId)
        {
            _userId = userId;
        }
        
        public IEnumerable<LessonListItem> GetLessons(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                   ctx
                       .Lessons
                       .Where(e => e.OwnerId == _userId)
                       .Select(
                           e =>
                               new LessonListItem
                               {
                                   LessonId = e.LessonId,
                                   LessonName = e.LessonName,
                                   Contents = e.Contents
                               }
                       );
                return query.ToArray();
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
                        .Single(e => e.LessonId == id && e.OwnerId == _userId);
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

