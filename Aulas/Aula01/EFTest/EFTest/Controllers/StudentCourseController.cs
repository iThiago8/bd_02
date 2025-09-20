using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

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
            return View(await studentCourseRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var students = await studentRepository.GetAll();

            var courses = await courseRepository.GetAll();

            ViewBag.StudentId = new SelectList(students, "Id", "FirstMidName");
            ViewBag.CourseId = new SelectList(courses, "Id", "Name");

            return View();
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
        public async Task<IActionResult> Update(int studentId, int courseId)
        {
            var studentCourse = await studentCourseRepository.Get(studentId, courseId);

            if (studentCourse == null)
                return NotFound();

            var students = await studentRepository.GetAll();

            var courses = await courseRepository.GetAll();

            ViewBag.StudentId = new SelectList(students, "Id", "FirstMidName", studentId);
            ViewBag.CourseId = new SelectList(courses, "Id", "Name", courseId);
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
        public async Task<IActionResult> Delete (int studentId, int courseId)
        {
            var studentCourse = await studentCourseRepository.Get(studentId, courseId);

            if (studentCourse == null)
                return NotFound();

            await studentCourseRepository.Delete(studentCourse);
            return RedirectToAction("Index");
        }
    }
}
