using EFTest.Interfaces;
using EFTest.Models;
using EFTest.ViewModels.StudentCourses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFTest.Controllers
{
    public class StudentCourseController(
        IStudentCourseRepository studentCourseRepository,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository
    ) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await studentRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateStudentCourseViewModel
            {
                Students = await studentRepository.GetAllNotEnrolled()
            };

            viewModel.SetCourses(
                await courseRepository.GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            foreach (var c in viewModel.SelectedCourses)
            {
                if (c.IsSelected)
                    await studentCourseRepository.Create(new StudentCourse
                    {
                        StudentId = viewModel.StudentId,
                        CourseId = c.Id,
                        EnrollmentDate = DateTime.Now
                    });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int studentId)
        {
            var enrolledCourses = await studentCourseRepository.GetByStudentId(studentId);

            var viewModel = new UpdateStudentCourseViewModel
            {
                SelectedStudent = await studentRepository.GetById(studentId)
            };

            viewModel.SetCourses(
                await courseRepository.GetAll()
            );

            foreach (var c in viewModel.SelectedCourses)
            {
                if (enrolledCourses!.Any(sc => sc.CourseId == c.Id))
                    c.IsSelected = true;
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStudentCourseViewModel viewModel)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete (int studentId)
        {
            return RedirectToAction("Index");
        }
    }
}
