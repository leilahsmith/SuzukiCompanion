using SuzukiCompanion.Models;
using System.Collections.Generic;

namespace SuzukiCompanion.Services
{
    public interface IStudentService
    {
        bool CreateStudent(StudentCreate model, string path);
        bool DeleteStudent(int studentId, string userId);
        StudentDetail GetStudentById(int studentId, string userId);
        IEnumerable<StudentListItem> GetStudents(string userId);
        bool UpdateStudent(StudentEdit model, string userId);
    }
}