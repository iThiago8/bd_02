using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class StudentCourseController(IStudentCourseRepository studentCourseRepository) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
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
    }
}
