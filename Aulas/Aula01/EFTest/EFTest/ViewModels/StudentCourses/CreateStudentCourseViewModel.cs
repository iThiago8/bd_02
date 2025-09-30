using EFTest.Models;

namespace EFTest.ViewModels.StudentCourses
{
    public class CreateStudentCourseViewModel
    {
        public int StudentId { get; set; }
        public List<Student> Students { get; set; } = [];
        public List<SelectedCourses> SelectedCourses { get; set; } = [];

        public void SetCourses(List<Course> courses)
        {
            SelectedCourses = [.. courses.Select(
                c => new SelectedCourses {
                    Id = c.Id,
                    Name = c.Name!,
                    IsSelected = false
                }
            )];
        }
    }
}
