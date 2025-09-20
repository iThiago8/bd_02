using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repositories
{
    public class StudentCourseRepository(SchoolContext context) : IStudentCourseRepository
    {
        public async Task Create(StudentCourse studentCourse)
        {
            await context.StudentCourse.AddAsync(studentCourse);
            await context.SaveChangesAsync();
        }
        public async Task Update(StudentCourse studentCourse)
        {
            context.StudentCourse.Update(studentCourse);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int studentId, int courseId)
        {
            var studentCourse = await context.StudentCourse.FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (studentCourse != null)
            {
                context.StudentCourse.Remove(studentCourse);
                await context.SaveChangesAsync();
            }
        }

        public async Task<StudentCourse?> Get(int studentId, int courseId)
        {
            return await
                context.StudentCourse
                .Include(s => s.Student)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }

        public async Task<List<StudentCourse>> GetAll()
        {
            return await
                context.StudentCourse
                .Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync();
        }
        public async Task<List<StudentCourse>?> GetByCourseId(int courseId)
        {
            return await
                context.StudentCourse
                .Where(sc => sc.CourseId == courseId)
                .Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync();
        }

        public async Task<List<StudentCourse>?> GetByStudentId(int studentId)
        {
            return await
                context.StudentCourse
                .Where(sc => sc.StudentId == studentId)
                .Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync();
        }

        public async Task<List<StudentCourse>> GetByCourseName(string name)
        {
            return await
                context.StudentCourse
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Where(sc => sc.Course!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }


        public async Task<List<StudentCourse>> GetByStudentName(string name)
        {
            return await
                context.StudentCourse
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Where(
                    sc =>   sc.Student!.FirstMidName!.ToLower().Contains(name.ToLower()) ||
                            sc.Student!.LastName!.ToLower().Contains(name.ToLower())                
                )
                .ToListAsync();
        }

    }
}
