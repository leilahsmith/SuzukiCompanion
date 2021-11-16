using SuzukiCompanion.Models;
using System.Collections.Generic;

namespace SuzukiCompanion.Services
{
    public interface IJourneyService
    {
        LessonDetail GetLessonById(int lessonId, string userId);
        IEnumerable<LessonListItem> GetLessons(string userId);
    }
}