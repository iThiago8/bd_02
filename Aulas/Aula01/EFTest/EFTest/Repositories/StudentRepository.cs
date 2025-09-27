using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repositories
{
    public class StudentRepository(SchoolContext context) : IStudentRepository
    {

        public async Task Create(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }
        public async Task Update(Student student)
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await 
                context.Students
                .Include(s => s.StudentCourses!)
                    .ThenInclude(sc => sc.Course)
                .ToListAsync();
        }

        public async Task<List<Student>> GetAllNotEnrolled()
        {
            var enrolledStudentIds =
                context.StudentCourse
                .Select(sc => sc.StudentId)
                .Distinct();

            return await 
                context.Students
                .Where(w => !enrolledStudentIds.Contains(w.Id))
                .OrderBy(s => s.FirstMidName)
                .ToListAsync();
            

        }

        public async Task<Student?> GetById(int id)
        {
            var student = 
                await context
                    .Students
                    .Where(s => s.Id == id)
                    .FirstOrDefaultAsync();

            return student;
        }

        public async Task<List<Student>> GetByName(string name)
        {
            var students =
                await context
                    .Students
                    .Where(s => s.FirstMidName!
                        .ToLower()
                        .Contains(name.ToLower())
                    )
                    .ToListAsync();

            return students;
        }

    }
}
