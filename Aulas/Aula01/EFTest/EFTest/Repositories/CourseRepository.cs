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

        public Task Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public Task<Course> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
