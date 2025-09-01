using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseController> _logger;

        public CourseController(
            ICourseRepository courseRepository, 
            ILogger<CourseController> logger
        )
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _courseRepository.GetAll());
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
                await _courseRepository.Create(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var course = await _courseRepository.GetById(id);
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
                await _courseRepository.Update(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetById(id);
            if (course == null)
                return NotFound();
         
            await _courseRepository.Delete(course);
            return RedirectToAction("Index");
        }

    }
}
