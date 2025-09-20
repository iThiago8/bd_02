using Microsoft.AspNetCore.Mvc;
using EFTest.Models;

namespace EFTest.Interfaces
{
    public interface IStudentCourseRepository
    {
        public Task Create(StudentCourse studentCourse);
        public Task Update(StudentCourse studentCourse);
        public Task Delete(StudentCourse studentCourse);

        public Task<List<StudentCourse>?> GetByStudentId(int studentId);
        public Task<List<StudentCourse>?> GetByCourseId(int courseId);
        public Task<StudentCourse?> Get(int studentId, int courseId);
        public Task<List<StudentCourse>> GetAll();
        public Task<List<StudentCourse>> GetByCourseName(string name);
        public Task<List<StudentCourse>> GetByStudentName(string name);
    }
}
