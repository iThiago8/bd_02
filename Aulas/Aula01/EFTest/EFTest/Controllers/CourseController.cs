using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFTest.Controllers
{
    public class CourseController(ICourseRepository courseRepository, ILogger logger) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await courseRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await courseRepository.Create(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var course = await courseRepository.GetById(id);
            if (course == null)
                return NotFound();
            else
                return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            if (ModelState.IsValid)
            {
                await courseRepository.Update(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await courseRepository.GetById(id);
            if (course == null)
                return NotFound();
         
            await courseRepository.Delete(course);
            return RedirectToAction("Index");
        }

    }
}
