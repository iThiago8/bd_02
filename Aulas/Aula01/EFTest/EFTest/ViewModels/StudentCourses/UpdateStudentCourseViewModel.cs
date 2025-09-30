using EFTest.Models;

namespace EFTest.ViewModels.StudentCourses
{
    public class UpdateStudentCourseViewModel
    {
        public Student SelectedStudent { get; set; } = new();
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
