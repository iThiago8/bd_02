using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repositories
{
    public class CourseRepository(SchoolContext context) : ICourseRepository
    {
        public async Task Create(Course course)
        {
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            context.Courses.Remove(course);
            await context.SaveChangesAsync();

        }

        public async Task<List<Course>> GetAll()
        {
            return await context.Courses.ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await context.Courses.FindAsync(id);
        }

        public Task<List<Course>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Course course)
        {
            context.Courses.Update(course);
            await context.SaveChangesAsync();

        }
    }
}
