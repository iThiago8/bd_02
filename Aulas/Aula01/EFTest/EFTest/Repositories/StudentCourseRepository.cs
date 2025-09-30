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

        public async Task DeleteEnrollments(int studentId)
        {
            var enrolledCourses = await
                context.StudentCourse
                .Where(sc => sc.StudentId == studentId
                && sc.WithdrawDate == null)
                .ToListAsync();

            foreach (var ec in enrolledCourses)
            {
                context.StudentCourse.Remove(ec);
            }

            await context.SaveChangesAsync();
        }

        public async Task<StudentCourse?> Get(int studentCourseId)
        {
            return await
                context.StudentCourse
                .Include(s => s.Student)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(sc => sc.Id == studentCourseId);
        }

        public async Task<List<StudentCourse>?> GetByStudentIdCourseId(int studentId, int courseId)
        {
            return await
                context.StudentCourse
                .Where(sc => sc.StudentId == studentId && sc.CourseId == courseId)
                .Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync();
        }

        public async Task<List<StudentCourse>> GetAll()
        {
            return await
                context.StudentCourse
                .Include(s => s.Student)
                .Include(c => c.Course)
                .OrderBy(sc => sc.EnrollmentDate)
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

        public async Task<StudentCourse?> GetActiveEnrollment(int studentId, int courseId)
        {
            return await
                context.StudentCourse
                .Where(sc => sc.StudentId == studentId && sc.CourseId == courseId && sc.WithdrawDate == null)
                .Include(s => s.Student)
                .Include(c => c.Course)
                .FirstOrDefaultAsync();
        }   
    }
}
