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
            var viewModel = new StudentCourseViewModel
            {
                Students = await studentRepository.GetAll()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCourse studentCourse)
        {
            if (!ModelState.IsValid)
                return View(studentCourse);

            await studentCourseRepository.Create(studentCourse);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var studentCourse = await studentCourseRepository.Get(id);

            if (studentCourse == null)
                return NotFound();

            var students = await studentRepository.GetAll();

            var courses = await courseRepository.GetAll();

            ViewBag.StudentId = new SelectList(students, "Id", "FirstMidName", studentCourse.StudentId);
            ViewBag.CourseId = new SelectList(courses, "Id", "Name", studentCourse.CourseId);
                return View(studentCourse);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentCourse studentCourse)
        {
            if (!ModelState.IsValid)
                return View(studentCourse);

            await studentCourseRepository.Update(studentCourse);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete (int studentCourseId)
        {
            var studentCourse = await studentCourseRepository.Get(studentCourseId);

            if (studentCourse == null)
                return NotFound();

            await studentCourseRepository.Delete(studentCourse);
            return RedirectToAction("Index");
        }
    }
}
