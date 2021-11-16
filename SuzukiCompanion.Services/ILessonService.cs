using SuzukiCompanion.Models;
using System.Collections.Generic;

namespace SuzukiCompanion.Services
{
    public interface ILessonService
    {
        bool CreateLesson(LessonCreate model, string path);
        bool DeleteLesson(int lessonId, string userId);
        LessonDetail GetLessonById(int lessonId, string userId);
        IEnumerable<LessonListItem> GetLessons(string userId);
        bool UpdateLesson(LessonEdit model);
        //object GetLessonById(string userId);
    }
}