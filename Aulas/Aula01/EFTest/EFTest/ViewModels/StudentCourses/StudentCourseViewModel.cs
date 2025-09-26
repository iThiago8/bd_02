using EFTest.Models;

namespace EFTest.ViewModels.StudentCourses
{
    public class StudentCourseViewModel
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

    public class SelectedCourses
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }
}
