using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;
        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public Task<List<Course>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

        }
    }
}
