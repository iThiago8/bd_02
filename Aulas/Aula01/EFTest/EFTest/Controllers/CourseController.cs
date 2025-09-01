using EFTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
